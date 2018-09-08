using DAO.Base;
using Entidades;
using Entidades.Filter;
using System.Collections.Generic;

namespace DAO.Interfaces
{
    public interface IMarcoDAO : IGenericDAO<Marco>
    {
        IList<Marco> GetByFilter(FilterMarco filter);
    }
}
