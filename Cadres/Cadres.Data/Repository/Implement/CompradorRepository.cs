using Cadres.Data.Base;
using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using System.Data.Entity;

namespace Cadres.Data.Repository.Implement
{
    public class CompradorRepository : GenericRepository<Comprador>, ICompradorRepository
    {
        public CompradorRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
