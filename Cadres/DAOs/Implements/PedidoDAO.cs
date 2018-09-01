using Base;
using DAO.Base;
using DAO.Interfaces;
using Entidades;
using Entidades.Filter;
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

        public IList<Pedido> GetByFilter(FilterPedido filter)
        {
            return this.GetAll().Where(x => x.Estado == filter.Estado
                                         || x.Fecha == filter.Fecha
                                         || x.Comprador.Nombre == filter.NombreComprador).ToList();
        }
    }
}
