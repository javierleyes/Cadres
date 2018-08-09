using Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfaces
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
        
    }
}
