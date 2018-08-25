using DAO.Interfaces;
using Entidades.Base;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAO.Base
{
    public class GenericDAO<TEntity, TKey> : GenericDAO<TEntity, TKey, DbContext>
        where TEntity : Entity<TKey>
        where TKey : IEquatable<TKey>
    {
        public GenericDAO(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public class GenericDAO<TEntity> : GenericDAO<TEntity, int, DbContext>
        where TEntity : Entity<int>
    {
        public GenericDAO(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public class GenericDAO<TEntity, TKey, TDbContext> : IGenericDAO<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
        where TDbContext : DbContext
    {
        protected virtual TDbContext DbContext { get; set; }

        public GenericDAO(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual IDbSet<TEntity> EntitySet
        {
            get
            {
                return DbContext.Set<TEntity>();
            }
        }

        public TEntity GetById(TKey id)
        {
            return GetAll().FirstOrDefault(e => e.Id.Equals(id));
        }

        public IQueryable<TEntity> GetAll()
        {
            return EntitySet;
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            EntitySet.AddOrUpdate(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            EntitySet.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            EntitySet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
            return entity;
        }
    }
}
