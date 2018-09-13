using Assembler;
using Base;
using DAO.Interfaces;
using Entidades;
using Entidades.DTO;
using Entidades.Filter;
using Services.Base;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implements
{
    public class PedidoService : GenericService<IPedidoDAO, Pedido, int>, IPedidoService
    {
        public IMarcoService MarcoService { get; set; }

        public PedidoService(IPedidoDAO entityDAO, IMarcoService marcoService) : base(entityDAO)
        {
            this.MarcoService = marcoService;
        }

        public IList<PedidoDTO> GetDTOAll()
        {
            return this.GetAll().Select(x => EntityConverter.ConvertPedidoToPedidoDTO(x)).ToList();
        }

        public PedidoDTO GetDTOById(int id)
        {
            Pedido pedido = this.GetById(id);

            return EntityConverter.ConvertPedidoToPedidoDTO(pedido);
        }

        public void AgregarPedido(PedidoDTO pedidoDTO)
        {
            if (pedidoDTO.Estado == Estados.EstadoPedido.Pendiente)
            {
                pedidoDTO.Precio = this.CalcularPrecioTotal(pedidoDTO);
            }

            Pedido pedido = EntityConverter.ConvertPedidoDTOToPedido(pedidoDTO);

            this.Save(pedido);
        }

        public decimal CalcularPrecioTotal(PedidoDTO pedidoDTO)
        {
            decimal total = 0;

            foreach (MarcoDTO marco in pedidoDTO.Marcos)
            {
                total += marco.Precio;
            }

            return total;
        }

        public void AgregarMarco(PedidoDTO pedidoDTO, MarcoDTO marcoDTO)
        {
            marcoDTO.Precio = this.MarcoService.CalcularPrecio(marcoDTO);
            pedidoDTO.Marcos.Add(marcoDTO);
            marcoDTO.Pedido = pedidoDTO;
        }

        public void AgregarComprador(PedidoDTO pedidoDTO, CompradorDTO compradorDTO)
        {
            pedidoDTO.Comprador = compradorDTO;
            compradorDTO.Pedido = pedidoDTO;
        }

        public void SetearEstadoTerminado(PedidoDTO pedidoDTO)
        {
            pedidoDTO.Estado = Estados.EstadoPedido.Terminado;

            this.ActualizarPedido(pedidoDTO);
        }

        public void SetearEstadoEntregado(PedidoDTO pedidoDTO)
        {
            pedidoDTO.Estado = Estados.EstadoPedido.Entregado;

            this.ActualizarPedido(pedidoDTO);
        }

        private void ActualizarPedido(PedidoDTO pedidoDTO)
        {
            if (pedidoDTO.Estado == Estados.EstadoPedido.Pendiente)
            {
                pedidoDTO.Precio = this.CalcularPrecioTotal(pedidoDTO);
            }

            Pedido pedido = this.GetById(pedidoDTO.Id);

            PedidoAssembler.ConvertPedidoDTOToPedido(pedido, pedidoDTO);

            this.Update(pedido);
        }

        public IList<PedidoDTO> GetByFilter(FilterPedido filter)
        {
            IList<PedidoDTO> pedidosDTO = new List<PedidoDTO>();

            return this.EntityDAO.GetByFilter(filter).Select(x => EntityConverter.ConvertPedidoToPedidoDTO(x)).ToList();
        }
    }
}
