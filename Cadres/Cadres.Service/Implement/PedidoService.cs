using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Domain.States;
using Cadres.Service.Base;
using Cadres.Service.Interface;
using System;
using System.Linq;

namespace Cadres.Service.Implement
{
    public class PedidoService : GenericService<IPedidoRepository, Pedido, long>, IPedidoService
    {
        public PedidoService(IPedidoRepository entityRepository) : base(entityRepository) { }

        public Pedido CrearNuevo()
        {
            Pedido pedido = new Pedido()
            {
                Numero = GetNumeroPedido(),
                Estado = Estados.EstadoPedido.Pendiente,
                Fecha = DateTime.Now,
            };

            return this.EntityRepository.Save(pedido);
        }

        public void AgregarMarco(int numeroPedido, Marco marco)
        {
            Pedido pedido = this.GetByNumero(numeroPedido);

            pedido.Marcos.Add(marco);

            this.EntityRepository.Update(pedido);
        }

        public Pedido GetByNumero(int numero)
        {
            return this.EntityRepository.GetAll().Where(x => x.Numero == numero).FirstOrDefault();
        }

        public void SetearEstadoEntregado(int numero)
        {
            ModificarEstado(numero, Estados.EstadoPedido.Entregado);
        }

        public void SetearEstadoTerminado(int numero)
        {
            ModificarEstado(numero, Estados.EstadoPedido.Terminado);
        }

        public void IngresarObservacion(int numeroPedido, string observacion)
        {
            Pedido pedido = this.EntityRepository.GetAll().Where(x => x.Numero == numeroPedido).FirstOrDefault();

            pedido.Observaciones = observacion;
        }

        private void ModificarEstado(int numero, Estados.EstadoPedido estado)
        {
            Pedido pedido = this.GetByNumero(numero);

            pedido.Estado = estado;

            EntityRepository.Update(pedido);
        }

        private int GetNumeroPedido()
        {
            return this.EntityRepository.GetAll().Count() + 1;
        }
    }
}
