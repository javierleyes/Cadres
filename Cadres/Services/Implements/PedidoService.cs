using Base;
using DAOs.Implements;
using Entidades;
using Entidades.DTOs;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Implements
{
    public class PedidoService : GenericService<PedidoDAO, Pedido, int>, IPedidoService
    {
        public PedidoService(PedidoDAO entityDAO) : base(entityDAO)
        {
        }

        public IList<PedidoDTO> GetByEstado(Estados.EstadoPedido estado)
        {
            IList<PedidoDTO> pedidosDTO = new List<PedidoDTO>();

            foreach (Pedido pedido in EntityDAO.GetByEstado(estado))
            {
                pedidosDTO.Add(EntityConverter.ConvertoPedidoToPedidoDTO(pedido));
            }

            return pedidosDTO;
        }
    }
}
