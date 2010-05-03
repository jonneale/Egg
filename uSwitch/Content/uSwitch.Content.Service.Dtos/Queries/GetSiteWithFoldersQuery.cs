using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using uSwitch.Content.Service.Model;

namespace uSwitch.Content.Common.Queries
{
	public class GetSiteWithFoldersQuery : IQuery<Site>
	{
		public Site Execute(ISession session)
		{
			throw new NotImplementedException();
		}
	}
}