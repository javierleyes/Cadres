using Cadres.Domain.Base;
using System;
using System.Data.Entity;
using System.Linq;

namespace Cadres.Data.Base
{
    // Generic method
    public class GenericRepository<TEntity, TKey> : GenericRepository<TEntity, TKey, DbContext>
    where TEntity : Domain<TKey>
    where TKey : IEquatable<TKey>
    {
        public GenericRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    // When Id is int
    public class GenericRepository<TEntity> : GenericRepository<TEntity, long, DbContext>
        where TEntity : Domain<long>
    {
        public GenericRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public class GenericRepository<TEntity, TKey, TDbContext> : IGenericRepository<TEntity, TKey>
        where TEntity : class, IDomain<TKey>
        where TKey : IEquatable<TKey>
        where TDbContext : DbContext
    {
        protected virtual TDbContext DbContext { get; set; }

        public GenericRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual DbSet<TEntity> EntitySet
        {
            get { return DbContext.Set<TEntity>(); }
        }

        #region Methods

        public TEntity GetById(TKey id)
        {
            return GetAll().FirstOrDefault(e => e.Id.Equals(id));
        }

        public IQueryable<TEntity> GetAll()
        {
            return EntitySet;
        }

        public TEntity Save(TEntity entity)
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

        #endregion
    }
}
