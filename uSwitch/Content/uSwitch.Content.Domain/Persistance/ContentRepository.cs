using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace uSwitch.Content.Domain.Persistance
{
	public class ContentRepository : Repository<ContentBase>
	{
		public ContentRepository(ISession session) : base(session)
		{
		}

		public ContentBase FindByNameAndPath(string name, string path)
		{
			return session.Linq<ContentBase>().Single(c => c.Path.Equals(path) && c.Name.Equals(name));
		}
	}
}