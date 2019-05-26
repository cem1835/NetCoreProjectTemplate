using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataStorage.Implementations.BaseServices
{
    public interface IRepository<T> where T: class,IEntity, new()
    {
        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        IEnumerable<T> GetList();

        IQueryable<T> GetListQueryable();

        IEnumerable<T> GetList(Expression<Func<T, bool>> _lamda);


        T FirstOrDefault(Expression<Func<T, bool>> _lamda);

        bool Any(Expression<Func<T, bool>> _lamda);
    }
}
