using Cadres.Data.Base;
using Cadres.Data.Filter;
using Cadres.Domain.Entity;
using System.Collections.Generic;

namespace Cadres.Data.Repository.Interface
{
    public interface IVarillaRepository : IGenericRepository<Varilla>
    {
        IList<Varilla> GetByFilter(VarillaFilter filter);
    }
}
