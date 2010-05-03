using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Testing.Selenium.Factories;
using StructureMap;
using StructureMap.Attributes;

namespace LiveNation.Testing.Selenium.IOC
{
	public class BootScrapper
	{
		private static readonly object _syncObject = new object();
		private static bool _started;

		public void Configure()
		{
			lock (_syncObject)
			{
				if (!_started)
				{
					var container = new Container();
					Configure(container);
					_started = true;
				}
			}
		}

		public void Configure(IContainer container)
		{
			lock (_syncObject)
			{
				if (!_started)
				{
					new Testing.Domain.IOC.BootStrapper()
						.Configure(container)
						.SetContainerOnServiceLocater(container);

					container.Configure(x =>
					                    x.ForRequestedType<ISeleniumFactory>()
					                    	.TheDefaultIsConcreteType<SeleniumFactory>());

					container.Configure(
						x =>
						x.ForRequestedType<SeleniumContext>()
							.CacheBy(InstanceScope.ThreadLocal)
							.TheDefaultIsConcreteType
							<SeleniumContext>());

					_started = true;
				}
			}
		}
	}
}