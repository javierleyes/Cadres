using Base;
using Entidades;
using System.Collections.Generic;

namespace DAOs.Interfaces
{
    public interface IPedidoDAO : IGenericDAO<Pedido>
    {
        IList<Pedido> GetByEstado(Estados.EstadoPedido estado);
    }
}
