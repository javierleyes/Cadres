using DAL.Interfaces;
using Entidades.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Implements
{
    public class BaseRepository<TEntity, TKey> : BaseRepository<TEntity, TKey, DbContext>
        where TEntity : Entity<TKey>
        where TKey : IEquatable<TKey>
    {
        public BaseRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public class BaseRepository<TEntity> : BaseRepository<TEntity, int, DbContext>
        where TEntity : Entity<int>
    {
        public BaseRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public class BaseRepository<TEntity, TKey, TDbContext> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
        where TDbContext : DbContext
    {
        protected virtual TDbContext DbContext { get; set; }

        public BaseRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual DbSet<TEntity> EntitySet
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


    }
}
