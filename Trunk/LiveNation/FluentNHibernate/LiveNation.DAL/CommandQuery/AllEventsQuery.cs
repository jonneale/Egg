using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.DAL.Model;
using NHibernate;

namespace LiveNation.DAL.CommandQuery
{
	public class AllEventsQuery : IQuery<IEnumerable<Event>>
	{
		public IEnumerable<Event> Execute(ISession session)
		{
			var criteria = session.CreateCriteria(typeof (Event));
			return criteria.List().Cast<Event>().ToArray();
		}
	}
}
