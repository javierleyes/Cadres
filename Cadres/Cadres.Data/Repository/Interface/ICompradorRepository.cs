using Cadres.Data.Base;
using Cadres.Data.Filter;
using Cadres.Domain.Entity;
using System.Collections.Generic;

namespace Cadres.Data.Repository.Interface
{
    public interface ICompradorRepository : IGenericRepository<Comprador>
    {
        IList<Comprador> GetByFilter(CompradorFilter filter);
    }
}
