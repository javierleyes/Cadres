using Cadres.Domain.Base;
using System;
using System.Linq;

namespace Cadres.Data.Base
{
    public interface IGenericRepository<TEntity> : IGenericRepository<TEntity, long> where TEntity : IDomain<long> { }

    public interface IGenericRepository<TEntity, TKey> where TKey : IEquatable<TKey>
    {
        TEntity GetById(TKey id);

        IQueryable<TEntity> GetAll();

        TEntity Save(TEntity entity);

        TEntity Update(TEntity entity);
    }
}
