using Base;
using DAO.Base;
using DAO.Interfaces;
using Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAO.Implements
{
    public class PedidoDAO : GenericDAO<Pedido>, IPedidoDAO
    {
        public PedidoDAO(DbContext dbContext) : base(dbContext)
        {
        }

        public IList<Pedido> GetByEstado(Estados.EstadoPedido estado)
        {
            return this.GetAll().Where(x => x.Estado == estado).ToList();
        }
    }
}
