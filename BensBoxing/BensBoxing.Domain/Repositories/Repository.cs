using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace BensBoxing.Domain.Repositories
{
    public class Repository<TClass> where TClass : Entity
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public IQueryable<TClass> All()
        {
            //return _session.CreateCriteria<TClass>().List<TClass>().AsQueryable();
            return _session.Linq<TClass>();
        }

        public TClass Get(int id)
        {
            return _session.Get<TClass>(id);
        }
    }
}
