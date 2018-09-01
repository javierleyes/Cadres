using Base;
using DAO.Base;
using Entidades;
using Entidades.Filter;
using System.Collections.Generic;

namespace DAO.Interfaces
{
    public interface IPedidoDAO : IGenericDAO<Pedido>
    {
        IList<Pedido> GetByFilter(FilterPedido filter);
    }
}
