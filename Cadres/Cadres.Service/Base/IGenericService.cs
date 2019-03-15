using Cadres.Data.Base;
using Cadres.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadres.Service.Base
{
    public interface IGenericService<TRepository, TEntity>
        where TRepository : IGenericRepository<TEntity, long>
        where TEntity : IDomain<long>
    {
    }

    public interface IGenericService<TRepository, TEntity, TKey>
        where TRepository : IGenericRepository<TEntity, TKey>
        where TEntity : IDomain<TKey>
        where TKey : IEquatable<TKey>
    {
        TEntity GetById(TKey id);

        IList<TEntity> GetAll();

        TEntity Save(TEntity entity);

        TEntity Update(TEntity entity);
    }
}
