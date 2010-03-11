using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Domain.Persistance
{
	public interface IRepository<TEntity>
	{
		TEntity Get(int id);
		TEntity Delete(int id);
		TEntity Add(TEntity entity);
		IEnumerable<TEntity> All();
	}
}
