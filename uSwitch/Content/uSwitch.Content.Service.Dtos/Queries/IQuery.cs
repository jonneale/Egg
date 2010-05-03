using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;

namespace uSwitch.Content.Common.Queries
{
	public interface IQuery<TResult>
	{
		TResult Execute(ISession session);
	}
}