using Base;
using DAO.Interfaces;
using Entidades;
using Entidades.DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IPedidoService : IGenericService<IPedidoDAO, Pedido, int>
    {
        void Insert(PedidoDTO pedidoDTO);

        PedidoDTO GetDTOById(int id);

        IList<PedidoDTO> GetDTOAll();

        IList<PedidoDTO> GetByEstado(Estados.EstadoPedido estado);

        decimal CalcularPrecio(PedidoDTO pedidoDTO);
    }
}
