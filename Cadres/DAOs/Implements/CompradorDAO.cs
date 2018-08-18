using DAOs.Filter;
using DAOs.Interfaces;
using Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAOs.Implements
{
    public class CompradorDAO : GenericDAO<Comprador>, ICompradorDAO
    {
        public CompradorDAO(DbContext dbContext) : base(dbContext)
        {
        }

        public IList<Comprador> GetByFilter(FilterComprador filter)
        {
            return this.GetAll().Where(x => x.Nombre == filter.Nombre
                                  || x.Direccion == filter.Direccion
                                  || x.Telefono == filter.Telefono).ToList();
        }
    }
}
