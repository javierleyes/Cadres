using Entidades;
using System.Data.Entity;

namespace DAOs.Implements
{
    public class PedidoDAO : GenericDAO<Pedido>
    {
        public PedidoDAO(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
