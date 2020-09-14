using Cadres.Domain.Entity;
using Cadres.Infrastructure.Base;
using Cadres.Infrastructure.Repository.Interface;

namespace Cadres.Infrastructure.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
        }
    }
}
