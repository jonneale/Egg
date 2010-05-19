using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using StructureMap;

namespace uSwitch.MvcBrownBag.Web.Core
{
	public class Bootstrapper
	{
		public Bootstrapper Configure()
		{
			//Domain.NHibernate.Configuration.Setup();
			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(new ApplicationViewEngine());

			ObjectFactory.Configure(x => x.AddRegistry<WebRegistry>());
			return this;
		}
	}
}