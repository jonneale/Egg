using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;

namespace uSwitch.Content.Domain.Ioc
{
	public class ServiceLocator : IServiceLocator
	{
		private readonly IWindsorContainer _container;

		public ServiceLocator(IWindsorContainer container)
		{
			_container = container;
		}

		public TInstance GetInstance<TInstance>()
		{
			return default(TInstance);
		}

		public IEnumerable<TInstance> GetInstances<TInstance>()
		{
			return default(IEnumerable<TInstance>);
		}

		public TInstance GetInstance<TInstance>(string @default)
		{
			return default(TInstance);
		}
	}
}
