﻿using Core.DataAccess.Repositories.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.Repositories.Concrete;
public class EntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
where TEntity : class, IEntity, new()
where TContext : DbContext, new()
{
    public void Add(TEntity entity)
    {
        using (var context = new TContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Delete(TEntity entity)
    {
        using (var context = new TContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using (var context = new TContext())
        {
            return context.Set<TEntity>().SingleOrDefault(filter);
        }
    }

    public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
    {
        using (var context = new TContext())
        {
            return filter is null
                         ? context.Set<TEntity>().ToList()
                         : context.Set<TEntity>().Where(filter).ToList();
        }
    }

    public void Update(TEntity entity)
    {
        using (var context = new TContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

