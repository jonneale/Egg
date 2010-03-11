using System;
using System.Collections.Generic;

namespace uSwitch.Content.Domain.Persistance
{
	public class ContentRepository : IRepository<ContentBase>
	{
		public ContentBase Get(int id)
		{
			throw new NotImplementedException();
		}

		public ContentBase Delete(int id)
		{
			throw new NotImplementedException();
		}

		public ContentBase Add(ContentBase entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ContentBase> All()
		{
			throw new NotImplementedException();
		}
	}
}