using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NHibernate;
using uSwitch.Content.Domain.Ioc;
using uSwitch.Content.Domain.Persistance.NHibernate;

namespace uSwitch.Content.Domain
{
	public class BootStrapper
	{
		public BootStrapper Configure()
		{
			NHibernateConfiguration.Configure();

			var container = new WindsorContainer();
			container.Register(Component.For<IWindsorContainer>()
			                   	.Instance(container),

			                   Component.For<ISessionFactory>()
			                   	.UsingFactoryMethod(() => NHibernateConfiguration.GetFactory()),

								Component.For<IServiceLocator>()
			                   	.ImplementedBy<ServiceLocator>(),
								
								Component.For<ISession>()
								.UsingFactoryMethod((k, c) => k.Resolve<ISessionFactory>().OpenSession()));



			return this;
		}
	}
}
