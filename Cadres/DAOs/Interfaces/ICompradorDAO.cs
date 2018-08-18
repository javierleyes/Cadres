using DAOs.Filter;
using Entidades;
using System.Collections.Generic;

namespace DAOs.Interfaces
{
    public interface ICompradorDAO : IGenericDAO<Comprador>
    {
        IList<Comprador> GetByFilter(FilterComprador filter);
    }
}
