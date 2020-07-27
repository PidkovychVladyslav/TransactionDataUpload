using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TransactionDataUpload.Data.Entities;
using TransactionDataUpload.Data.Repositories.Abstraction.Base;

namespace TransactionDataUpload.Data.Repositories.Implementation.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BasicEntity
    {
        #region Properties

        protected DbContext Context { get; }
        protected DbSet<TEntity> Set { get; }


        #endregion

        #region Constructors

        public Repository(DbContext context)
        {
            Context = context;
            Set = context.Set<TEntity>();
        }

        #endregion

        #region Interface members

        protected virtual IQueryable<TEntity> Include()
        {
            return Set;
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return Include().AsEnumerable();
        }

        public virtual TEntity Get(int id)
        {
            return Include().FirstOrDefault(i => i.Id == id);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            return Include().FirstOrDefault(filter);
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return Include().Where(filter);
        }

        public IQueryable<TEntity> With<TProperty>(Expression<Func<TEntity, TProperty>> include)
        {
            return Include().Include(include);
        }

        public IQueryable<TEntity> With(string include)
        {
            return Include().Include(include);
        }

        public virtual TEntity Create(TEntity entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
                return entity;
            }

            return Set.Add(entity);
        }

        public virtual IEnumerable<TEntity> Create(IEnumerable<TEntity> entities)
        {
            return Set.AddRange(entities);
        }

        public virtual TEntity Update(TEntity entity)
        {
            var entry = Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
            }

            if (entry.State != EntityState.Modified)
            {
                entry.State = EntityState.Modified;
            }

            return entity;
        }

        public virtual void Delete(int id)
        {
            var entity = Set.Find(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            var entry = Context.Entry(entity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
        }

        public bool Exists(int id)
        {
            return Set.Any(i => i.Id == id);
        }

        #endregion
    }
}
