using Cadres.Assembler.Interface;
using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Domain.States;
using Cadres.Dto;
using Cadres.Service.Base;
using Cadres.Service.Filter;
using Cadres.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadres.Service.Implement
{
    public class PedidoService : GenericService<IPedidoRepository, Pedido, long>, IPedidoService
    {
        public IMarcoRepository MarcoRepository { get; set; }

        public IMarcoAssembler MarcoAssembler { get; set; }

        public PedidoService(IPedidoRepository entityRepository, IMarcoRepository marcoRepository, IMarcoAssembler marcoAssembler) : base(entityRepository)
        {
            this.MarcoRepository = marcoRepository;
            this.MarcoAssembler = marcoAssembler;
        }

        public PedidoDTO CrearNuevo()
        {
            Pedido pedido = new Pedido()
            {
                Numero = GetNumeroPedido(),
                Estado = Estados.EstadoPedido.Pendiente,
                FechaIngreso = DateTime.Now,
            };

            this.EntityRepository.Save(pedido);

            return this.ToDTO(pedido);
        }

        public void AgregarMarco(int numeroPedido, int numeroMarco)
        {
            Pedido pedido = this.GetEntidadByNumero(numeroPedido);

            Marco marco = this.MarcoRepository.GetAll().Where(x => x.Numero == numeroMarco).SingleOrDefault();

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


        public void SetearEstadoEntregado(int numero)
        {
            Pedido pedido = this.GetEntidadByNumero(numero);

            pedido.Estado = Estados.EstadoPedido.Entregado;
            pedido.FechaEntrega = DateTime.Now;

            EntityRepository.Update(pedido);
        }

        public void SetearEstadoTerminado(int numero)
        {
            Pedido pedido = this.GetEntidadByNumero(numero);

            pedido.Estado = Estados.EstadoPedido.Terminado;
            pedido.FechaTerminado = DateTime.Now;

            EntityRepository.Update(pedido);
        }

        public void IngresarObservacion(int numeroPedido, string observacion)
        {
            Pedido pedido = this.EntityRepository.GetAll().Where(x => x.Numero == numeroPedido).FirstOrDefault();

            pedido.Observaciones = observacion;
        }

        public PedidoDTO GetByNumero(int numero)
        {
            Pedido pedido = this.GetEntidadByNumero(numero);

            return this.ToDTO(pedido);
        }

        private Pedido GetEntidadByNumero(int numero)
        {
            return this.EntityRepository.GetAll().Where(x => x.Numero == numero).FirstOrDefault();
        }

        private PedidoDTO ToDTO(Pedido pedido)
        {
            PedidoDTO dto = new PedidoDTO()
            {
                Estado = pedido.Estado.ToString(),
                FechaIngreso = pedido.FechaIngreso,
                FechaEntrega = pedido.FechaEntrega,
                FechaTerminado = pedido.FechaTerminado,
                Id = pedido.Id,
                Numero = pedido.Numero,
                Observaciones = pedido.Observaciones,
                Precio = pedido.Precio,
            };

            foreach (long id in pedido.Marcos.Select(x => x.Id).ToList())
            {
                dto.MarcoIds.Add(id);
            }

            return dto;
        }

        public int GetNumeroPedido()
        {
            return this.EntityRepository.GetAll().Count() + 1;
        }

        public IList<PedidoDTO> GetByFilter(PedidoFilter filter)
        {
            IList<PedidoDTO> dtos = new List<PedidoDTO>();

            IList<Pedido> pedidos = this.EntityRepository.GetAll().Where(x => (int)x.Estado == filter.Estado).ToList();

            foreach (Pedido pedido in pedidos)
            {
                dtos.Add(this.ToDTO(pedido));
            }

            return dtos;
        }

        public IList<MarcoDTO> GetMarcosByNumeroPedido(int numero)
        {
            IList<MarcoDTO> dtos = new List<MarcoDTO>();

            Pedido pedido = this.GetEntidadByNumero(numero);

            foreach (Marco marco in pedido.Marcos)
            {
                dtos.Add(this.MarcoAssembler.ToDTO(marco));
            }

            return dtos;
        }
    }
}
