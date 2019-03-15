using Cadres.Data.Base;
using Cadres.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadres.Service.Base
{
    public class GenericService<TEntityRepository, TEntity, TKey> : IGenericService<TEntityRepository, TEntity, TKey>
        where TEntityRepository : IGenericRepository<TEntity, TKey>
        where TEntity : IDomain<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual TEntityRepository EntityRepository { get; set; }

        public GenericService(TEntityRepository entityRepository)
        {
            EntityRepository = entityRepository;
        }

        public TEntity GetById(TKey id)
        {
            return EntityRepository.GetById(id);
        }

        public IList<TEntity> GetAll()
        {
            return EntityRepository.GetAll().ToList();
        }

        public TEntity Save(TEntity entity)
        {
            return EntityRepository.Save(entity);
        }

        public TEntity Update(TEntity entity)
        {
            return EntityRepository.Update(entity);
        }
    }
}
