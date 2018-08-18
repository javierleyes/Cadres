using Base;
using Entidades;
using System.Collections.Generic;

namespace DAO.Interfaces
{
    public interface IPedidoDAO : IGenericDAO<Pedido>
    {
        IList<Pedido> GetByEstado(Estados.EstadoPedido estado);
    }
}
