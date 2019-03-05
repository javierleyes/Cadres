using Cadres.Data.Base;
using Cadres.Data.Filter;
using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cadres.Data.Repository.Implement
{
    public class VarillaRepository : GenericRepository<Varilla>, IVarillaRepository
    {
        public VarillaRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IList<Varilla> GetByFilter(VarillaFilter filter)
        {
            return this.GetAll().Where(x => x.Nombre.Contains(filter.Nombre)
                                         || x.Ancho == filter.Ancho
                                         || x.Disponible == filter.Disponible).ToList();
        }
    }
}
