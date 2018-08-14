using DAL.Interfaces.Base;
using Entidades.Base;
using Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implements.Base
{
    public class BaseService
        <TEntityRepository, TEntity, TKey> : IBaseService
        <TEntityRepository, TEntity, TKey>
        where TEntityRepository : IBaseRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual TEntityRepository EntityRepository { get; set; }

        public BaseService(TEntityRepository entityRepository)
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
            if (entity.IsTransient())
                return EntityRepository.Add(entity);
            else
                return EntityRepository.Update(entity);
        }
    }
}
