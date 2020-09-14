using Cadres.Domain.Entity;
using Cadres.Infrastructure.Base;
using Cadres.Infrastructure.Repository.Interface;

namespace Cadres.Infrastructure.Repository
{
    public class RodRepository : BaseRepository<Rod>, IRodRepository
    {
        public RodRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
        }
    }
}
