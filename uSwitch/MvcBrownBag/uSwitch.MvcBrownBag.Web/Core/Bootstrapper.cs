using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace uSwitch.MvcBrownBag.Web.Core
{
	public class Bootstrapper
	{
		public Bootstrapper Configure()
		{
			Domain.NHibernate.Configuration.Setup();

			ObjectFactory.Configure(x => x.AddRegistry<WebRegistry>());
			return this;
		}
	}
}