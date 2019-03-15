using Cadres.Data.Base;
using Cadres.Data.Filter;
using Cadres.Domain.Entity;
using System.Collections.Generic;

namespace Cadres.Data.Repository.Interface
{
    public interface IMarcoRepository : IGenericRepository<Marco>
    {
        IList<Marco> GetByFilter(MarcoFilter filter);
    }
}
