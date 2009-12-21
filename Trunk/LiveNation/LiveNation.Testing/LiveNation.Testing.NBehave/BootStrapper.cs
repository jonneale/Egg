using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace LiveNation.Testing.NBehave
{
	public class BootStrapper
	{
		public BootStrapper Configure()
		{
			var container = new Container();
			new LiveNation.Testing.Domain.IOC.BootStrapper().Configure(container);

			return Configure(container);
		}

		public BootStrapper Configure(IContainer container)
		{
			container.Configure(

			return this;
		}
	}
}
