using DAO.Base;
using DAO.Interfaces;
using Entidades;
using Entidades.Filter;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAO.Implements
{
    public class MarcoDAO : GenericDAO<Marco>, IMarcoDAO
    {
        public MarcoDAO(DbContext dbContext) : base(dbContext)
        {
        }

        public IList<Marco> GetByFilter(FilterMarco filter)
        {
            return this.GetAll().Where(x => x.Ancho == filter.Ancho
                                         || x.Largo == filter.Largo
                                         || x.Estado == filter.Estado
                                         || x.Varilla.Nombre == filter.Varilla.Nombre
                                         || x.Varilla.Ancho == filter.Varilla.Ancho).ToList();
        }
    }
}
