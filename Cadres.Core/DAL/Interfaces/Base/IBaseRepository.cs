using Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Interfaces.Base
{
    public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, int>
        where TEntity : IEntity<int>
    {
    }

    public interface IBaseRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TEntity GetById(TKey id);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);
        
    }
}
