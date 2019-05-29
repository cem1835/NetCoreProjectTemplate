using DataStorage.Implementations.BaseServices;
using Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NHibernate.Linq;

namespace DataStorage.Core.NHibernate
{
    public class NhEntityRepositoryBase<Tentity> : IRepository<Tentity> where Tentity : class, IEntity, new()
    {

        private NHibernateHelper _nHibernateHelper;

        public NhEntityRepositoryBase(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public Tentity Add(Tentity entity)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                session.Save(entity);
                return entity;
            }
        }

        public bool Any(Expression<Func<Tentity, bool>> _lamda)
        {
            throw new NotImplementedException();
        }

        public void Delete(Tentity entity)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                session.Delete(entity);
            }
        }

        public Tentity FirstOrDefault(Expression<Func<Tentity, bool>> _lamda)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                return session.Query<Tentity>().SingleOrDefault(_lamda);
            }
        }

        public IEnumerable<Tentity> GetList()
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                return session.Query<Tentity>().ToList();
            }
        }

        public IEnumerable<Tentity> GetList(Expression<Func<Tentity, bool>> _lamda)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                return session.Query<Tentity>().Where(_lamda).ToList();
            }
        }

        public IQueryable<Tentity> GetListQueryable()
        {
            throw new NotImplementedException();
        }

        public Tentity Update(Tentity entity)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                session.Update(entity);
                return entity;
            }
        }
    }
}
