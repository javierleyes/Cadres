using Cadres.Data.Base;
using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using System.Data.Entity;

namespace Cadres.Data.Repository.Implement
{
    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
