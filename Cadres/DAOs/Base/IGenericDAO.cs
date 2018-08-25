using Entidades.Base;
using System;
using System.Linq;

namespace DAO.Base
{
    public interface IGenericDAO<TEntity> : IGenericDAO<TEntity, int>
        where TEntity : IEntity<int>
    {
    }

    public interface IGenericDAO<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TEntity GetById(TKey id);

        IQueryable<TEntity> GetAll();

        // DELETE
        TEntity InsertOrUpdate(TEntity entity);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);
    }
}
