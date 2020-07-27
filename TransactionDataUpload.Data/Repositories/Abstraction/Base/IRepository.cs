using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TransactionDataUpload.Data.Entities;

namespace TransactionDataUpload.Data.Repositories.Abstraction.Base
{
    public interface IRepository<TEntity> where TEntity : BasicEntity
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        TEntity Find(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> With<TProperty>(Expression<Func<TEntity, TProperty>> include);
        IQueryable<TEntity> With(string include);
        TEntity Create(TEntity entity);
        IEnumerable<TEntity> Create(IEnumerable<TEntity> entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        bool Exists(int id);
    }
}
