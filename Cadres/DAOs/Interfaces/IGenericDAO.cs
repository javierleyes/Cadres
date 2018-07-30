using System.Collections.Generic;

namespace DAOs.Interfaces
{
    public interface IGenericDAO<T>
    {
        IList<T> GetAll();

        T GetById(long id);

        void Add(T entidad);
    }
}
