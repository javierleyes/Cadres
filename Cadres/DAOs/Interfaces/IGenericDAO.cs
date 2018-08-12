using Entidades.Base;
using System;
using System.Linq;

namespace DAOs.Interfaces
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

        TEntity InsertOrUpdate(TEntity entity);
    }
}
