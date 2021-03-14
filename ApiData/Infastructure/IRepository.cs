using ApiModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ApiData.Infastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        EntityEntry<TEntity> Add(TEntity entity);
        EntityEntry<TEntity> Update(TEntity entity);
        EntityEntry<TEntity> Delete(TEntity entity);
        IEnumerable<EntityEntry<TEntity>> Delete(Expression<Func<TEntity, bool>> where);
        TEntity GetById(int id);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
    }
}
