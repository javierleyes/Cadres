using DAL.Interfaces.Base;
using Entidades.Operaciones;
using Filters.Operaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfaces.Operaciones
{
    public interface ICompradorRepository : IBaseRepository<Comprador>
    {
        IQueryable<Comprador> GetByFilter(CompradorFilter filter);
    }
}
