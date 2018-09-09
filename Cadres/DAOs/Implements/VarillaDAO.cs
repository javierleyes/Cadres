using DAO.Base;
using DAO.Interfaces;
using Entidades;
using Entidades.Filter;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAO.Implements
{
    public class VarillaDAO : GenericDAO<Varilla>, IVarillaDAO
    {
        public VarillaDAO(DbContext dbContext) : base(dbContext)
        {
        }

        public IList<Varilla> GetByFilter(FilterVarilla filter)
        {
            return this.GetAll().Where(x => x.Nombre == filter.Nombre ||
                                            x.Ancho == filter.Ancho ||
                                            x.Disponible == filter.Disponible).ToList();
        }
    }
}