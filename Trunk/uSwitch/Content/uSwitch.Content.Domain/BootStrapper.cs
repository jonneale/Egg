using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using uSwitch.Content.Domain.Ioc;

namespace uSwitch.Content.Domain
{
	public class BootStrapper
	{
		public BootStrapper Configure()
		{
			var container = new WindsorContainer();
			container.Register(Component.For<IWindsorContainer>()
								.Instance(container),

								Component.For<IServiceLocator>()
			                   	.ImplementedBy<ServiceLocator>());

			return this;
		}
	}
}
