using DAL.Interfaces.Base;
using Entidades.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Base
{
    public interface IBaseService<TDAO, TEntity> : IBaseService<TDAO, TEntity, int>
        where TDAO : IBaseRepository<TEntity, int>
        where TEntity : IEntity<int>
    {
    }

    public interface IBaseService<TDAO, TEntity, TKey>
        where TDAO : IBaseRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TEntity GetById(TKey id);

        IList<TEntity> GetAll();

        TEntity Save(TEntity entity);
    }
}
