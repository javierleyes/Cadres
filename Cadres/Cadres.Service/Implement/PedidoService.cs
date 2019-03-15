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

            if (pedido.Precio == null)
            {
                pedido.Precio = marco.Precio;
            }
            else
            {
                pedido.Precio = pedido.Precio + marco.Precio;
            }


            this.EntityRepository.Update(pedido);
        }

        public Pedido GetByNumero(int numero)
        {
            return this.EntityRepository.GetAll().Where(x => x.Numero == numero).FirstOrDefault();
        }

        public void SetearEstadoEntregado(int numero)
        {
            Pedido pedido = this.GetByNumero(numero);

            pedido.Estado = Estados.EstadoPedido.Entregado;
            pedido.FechaEntrega = DateTime.Now;

            EntityRepository.Update(pedido);
        }

        public void SetearEstadoTerminado(int numero)
        {
            Pedido pedido = this.GetByNumero(numero);

            pedido.Estado = Estados.EstadoPedido.Terminado;
            pedido.FechaTerminado = DateTime.Now;

            EntityRepository.Update(pedido);
        }

        public void IngresarObservacion(int numeroPedido, string observacion)
        {
            Pedido pedido = this.EntityRepository.GetAll().Where(x => x.Numero == numeroPedido).FirstOrDefault();

            pedido.Observaciones = observacion;
        }

        private int GetNumeroPedido()
        {
            return this.EntityRepository.GetAll().Count() + 1;
        }
    }
}
