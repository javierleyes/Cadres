using Entidades;
using Entidades.Filter;
using System.Collections.Generic;

namespace DAOs.Interfaces
{
    public interface ICompradorDAO : IGenericDAO<Comprador>
    {
        IList<Comprador> GetByFilter(FilterComprador filter);
    }
}
