using Cadres.Data.Base;
using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using System.Data.Entity;

namespace Cadres.Data.Repository.Implement
{
    public class MarcoRepository : GenericRepository<Marco>, IMarcoRepository
    {
        public MarcoRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
