using DAO.Base;
using Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Base
{
    public class GenericService
        <TEntityDAO, TEntity, TKey> : IGenericService<TEntityDAO, TEntity, TKey>
        where TEntityDAO : IGenericDAO<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual TEntityDAO EntityDAO { get; set; }

        public GenericService(TEntityDAO entityDAO)
        {
            EntityDAO = entityDAO;
        }

        public TEntity GetById(TKey id)
        {
            return EntityDAO.GetById(id);
        }

        public IList<TEntity> GetAll()
        {
            return EntityDAO.GetAll().ToList();
        }

        public TEntity Save(TEntity entity)
        {
            return EntityDAO.InsertOrUpdate(entity);
        }

        public TEntity Update(TEntity entity)
        {
            return EntityDAO.Update(entity);
        }
    }
}
