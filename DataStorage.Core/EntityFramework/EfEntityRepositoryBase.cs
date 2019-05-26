using DataStorage.Implementations.BaseServices;
using Microsoft.EntityFrameworkCore;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataStorage.Core.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IRepository<TEntity> where TEntity : class, IEntity, new()
                                                                                 where TContext : DbContext, new()
    {
        public bool Any(Expression<Func<TEntity, bool>> _lamda)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deleteObj = context.Entry(entity);
                deleteObj.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }


        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> lamda)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(lamda);
            }
        }

        public IEnumerable<TEntity> GetList()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> lamda)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(lamda).ToList();
            }
        }

        public IQueryable<TEntity> GetListQueryable()
        {
            throw new NotImplementedException();
        }

        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addingObj = context.Entry(entity);
                addingObj.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedObj = context.Entry(entity);
                updatedObj.State = EntityState.Modified;
                context.SaveChanges();

                return entity;
            }
        }
    }
}
