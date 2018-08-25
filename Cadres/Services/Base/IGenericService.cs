using DAO.Base;
using DAO.Interfaces;
using Entidades.Base;
using System;
using System.Collections.Generic;

namespace Services.Base
{
    public interface IGenericService<TDAO, TEntity>
        where TDAO : IGenericDAO<TEntity, int>
        where TEntity : IEntity<int>
    {
    }

    public interface IGenericService<TDAO, TEntity, TKey>
        where TDAO : IGenericDAO<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TEntity GetById(TKey id);

        IList<TEntity> GetAll();

        TEntity Save(TEntity entity);

        TEntity Update(TEntity entity);
    }
}
