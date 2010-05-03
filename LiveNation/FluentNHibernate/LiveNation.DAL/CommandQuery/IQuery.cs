using System;
using System.Linq;
using System.Text;
using NHibernate;

namespace LiveNation.DAL.CommandQuery
{
	public interface IQuery<TReturn>
	{
		TReturn Execute(ISession session);
	}
}
