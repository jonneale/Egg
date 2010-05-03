using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Domain.Persistance
{
	public interface IRepository<TEntity>
	{
		TEntity Get(int id);
		void Delete(TEntity entity);
		void Add(TEntity entity);
		IQueryable<TEntity> All();
	}
}
