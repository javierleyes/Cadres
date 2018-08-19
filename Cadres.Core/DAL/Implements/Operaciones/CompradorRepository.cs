using DAL.Implements.Base;
using DAL.Interfaces.Operaciones;
using Entidades.Operaciones;
using Filters.Operaciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Implements.Operaciones
{
    public class CompradorRepository : BaseRepository<Comprador>, ICompradorRepository
    {
        public CompradorRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Comprador> GetByFilter(CompradorFilter filter)
        {
            return this.GetWhere(x => x.Nombre == filter.Nombre
                                  || x.Direccion == filter.Direccion
                                  || x.Telefono == filter.Telefono);
        }
    }
}
