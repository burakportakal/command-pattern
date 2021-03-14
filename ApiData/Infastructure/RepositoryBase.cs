using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ApiData.Infastructure
{
    public abstract class RepositoryBase<TEntity, TContext>
        where TEntity : class
        where TContext : DbContext
    {
        private TContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        protected IDbFactory<TContext> DbFactory { get; private set; }

        protected TContext DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }

        protected RepositoryBase(IDbFactory<TContext> dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<TEntity>();
        }
        public virtual EntityEntry<TEntity> Add(TEntity entity)
        {
            return dbSet.Add(entity);
        }

        public virtual EntityEntry<TEntity> Update(TEntity entity)
        {
            return dbSet.Update(entity);
        }

        public virtual EntityEntry<TEntity> Delete(TEntity entity)
        {
            return dbSet.Remove(entity);
        }

        public virtual IEnumerable<EntityEntry<TEntity>> Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> objects = dbSet.Where<TEntity>(where).AsEnumerable();
            List<EntityEntry<TEntity>> result = new List<EntityEntry<TEntity>>();
            foreach(TEntity entity in objects)
            {
                result.Add(dbSet.Remove(entity));
            }
            return result;
        }

        public virtual TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.FirstOrDefault(where);
        }
    }
}
