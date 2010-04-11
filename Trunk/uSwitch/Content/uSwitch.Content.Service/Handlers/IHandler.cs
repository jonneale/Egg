using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Service.Handlers
{
	public interface IHandler<TCommandQuery>
	{
		void Execute(TCommandQuery commandQuery);
	}
}
