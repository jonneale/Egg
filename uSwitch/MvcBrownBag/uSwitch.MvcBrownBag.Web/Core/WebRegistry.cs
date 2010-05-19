using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using StructureMap.Configuration.DSL;
using uSwitch.MvcBrownBag.Domain.IOC;
using uSwitch.MvcBrownBag.Domain.NHibernate;
using uSwitch.MvcBrownBag.Web.Controllers;

namespace uSwitch.MvcBrownBag.Web.Core
{
	public class WebRegistry : Registry
	{
		public WebRegistry()
		{
			IncludeRegistry<DomainRegistry>();

			Scan(x =>
			     	{
			     		x.AssemblyContainingType<ApplicationController>();
			     		x.AddAllTypesOf<IController>();
			     	});

			For<ISession>()
				.HttpContextScoped()
//				.Use(x => x.GetInstance<ISessionFactory>().OpenSession());
				.Use(x => null);

			For<ISessionFactory>()
				.Use(x => Configuration.GetSessionFactory());
		}
	}
}
