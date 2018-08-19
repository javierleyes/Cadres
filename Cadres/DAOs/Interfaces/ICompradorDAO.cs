using DAO.Base;
using Entidades;
using Entidades.Filter;
using System.Collections.Generic;

namespace DAO.Interfaces
{
    public interface ICompradorDAO : IGenericDAO<Comprador>
    {
        IList<Comprador> GetByFilter(FilterComprador filter);
    }
}
