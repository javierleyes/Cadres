using Cadres.Data.Base;
using Cadres.Data.Filter;
using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Domain.States;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cadres.Data.Repository.Implement
{
    public class MarcoRepository : GenericRepository<Marco>, IMarcoRepository
    {
        public MarcoRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IList<Marco> GetByFilter(MarcoFilter filter)
        {
            return this.GetAll().Where(x => x.Ancho == filter.Ancho
                                         || x.Largo == filter.Largo
                                         || x.Estado == (Estados.EstadoMarco)filter.Estado
                                         || x.Varilla.Id == filter.IdVarilla).ToList();
        }
    }
}
