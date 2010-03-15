using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace uSwitch.Content.Domain.Persistance
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
	{
		protected readonly ISession session;

		public Repository(ISession session)
		{
			this.session = session;
		}

		public virtual TEntity Get(int id)
		{
			return session.Linq<TEntity>().Single(x => x.Id.Equals(id));
		}

		public virtual void Delete(TEntity entity)
		{
			session.Delete(entity);
		}

		public virtual void Add(TEntity entity)
		{
			session.Save(entity);
		}

		public virtual IQueryable<TEntity> All()
		{
			return session.Linq<TEntity>();
		}
	}
}