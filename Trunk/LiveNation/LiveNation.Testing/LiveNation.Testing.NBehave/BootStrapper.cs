using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Testing.Domain.Framework;
using StructureMap;

namespace LiveNation.Testing.NBehave
{
	public class BootStrapper
	{
		public BootStrapper Configure()
		{
			var container = new Container();
			new Domain.IOC.BootStrapper().Configure(container);

			return Configure(container);
		}

		public BootStrapper Configure(IContainer container)
		{
            container.Configure(c =>
            {
                c.ForRequestedType<IProcess>()
                    .TheDefaultIsConcreteType<Process>();

                c.ForRequestedType<System.Diagnostics.Process>()
                    .TheDefaultIsConcreteType<System.Diagnostics.Process>();

                c.ForRequestedType<NBehaveProcess>()
                    .TheDefaultIsConcreteType<NBehaveProcess>();

                c.ForRequestedType<NBehaveConsoleProcessStart>()
                    .TheDefaultIsConcreteType<NBehaveConsoleProcessStart>();
            });

			return this;
		}
	}
}
