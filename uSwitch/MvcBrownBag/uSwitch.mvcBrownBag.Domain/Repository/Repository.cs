using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;

namespace uSwitch.MvcBrownBag.Domain.Repository
{
	public class Repository : IRepository
	{
		private readonly ISession _session;

		public Repository(ISession session)
		{
			_session = session;
		}

		public void Add<TEntity>(TEntity entity) where TEntity : Entity
		{
			_session.Save(entity);
		}

		public TEntity Get<TEntity>(object id)
		{
			return _session.Get<TEntity>(id);
		}

		public void Delete<TEntity>(TEntity entity) where TEntity : Entity
		{
			_session.Delete(entity);
		}

		public IQueryable<TEntity> Query<TEntity>() where TEntity : Entity
		{
			return null;
		}

	    public IEnumerable<TEntity> All<TEntity>()
	    {
	        return _session.CreateCriteria(typeof (TEntity)).List<TEntity>();
	    }
	}
}