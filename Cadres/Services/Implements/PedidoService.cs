using Base;
using DAO.Implements;
using Entidades;
using Entidades.DTO;
using Services.Base;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implements
{
    public class PedidoService : GenericService<PedidoDAO, Pedido, int>, IPedidoService
    {
        public IMarcoService MarcoService { get; set; }

        public PedidoService(PedidoDAO entityDAO) : base(entityDAO)
        {
        }

        public IList<PedidoDTO> GetByEstado(Estados.EstadoPedido estado)
        {
            IList<PedidoDTO> pedidosDTO = new List<PedidoDTO>();

            foreach (Pedido pedido in EntityDAO.GetByEstado(estado))
            {
                pedidosDTO.Add(EntityConverter.ConvertPedidoToPedidoDTO(pedido));
            }

            return pedidosDTO;
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

        public void Insert(PedidoDTO pedidoDTO)
        {
            pedidoDTO.Precio = this.CalcularPrecioTotal(pedidoDTO);

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
        }
    }
}
