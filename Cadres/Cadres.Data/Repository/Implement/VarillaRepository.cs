using Cadres.Data.Base;
using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using System.Data.Entity;

namespace Cadres.Data.Repository.Implement
{
    public class VarillaRepository : GenericRepository<Varilla>, IVarillaRepository
    {
        public VarillaRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
