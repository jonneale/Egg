using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;

namespace uSwitch.Content.Domain.Persistance
{
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		private readonly IWindsorContainer _container;

		public UnitOfWorkFactory(IWindsorContainer container)
		{
			_container = container;
		}

		public UnitOfWork Create()
		{
			return _container.Resolve<UnitOfWork>();
		}
	}
}
