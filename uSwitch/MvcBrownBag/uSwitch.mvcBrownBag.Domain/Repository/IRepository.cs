using System.Linq;

using System.Collections.Generic;

namespace uSwitch.MvcBrownBag.Domain.Repository
{
	public interface IRepository
	{
		void Add<TEntity>(TEntity entity) where TEntity : Entity;
		TEntity Get<TEntity>(object id);
		void Delete<TEntity>(TEntity entity) where TEntity : Entity;
		IQueryable<TEntity> Query<TEntity>() where TEntity : Entity;
        IEnumerable<TEntity> All<TEntity>();
	}
}