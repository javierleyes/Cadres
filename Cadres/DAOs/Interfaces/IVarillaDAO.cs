using DAO.Base;
using Entidades;
using Entidades.Filter;
using System.Collections.Generic;

namespace DAO.Interfaces
{
    public interface IVarillaDAO : IGenericDAO<Varilla>
    {
        IList<Varilla> GetByFilter(FilterVarilla filter);
    }
}
