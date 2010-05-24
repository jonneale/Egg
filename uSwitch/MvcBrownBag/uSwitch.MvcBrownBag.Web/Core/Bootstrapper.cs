using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;
using StructureMap;
using uSwitch.MvcBrownBag.Web.Core.DataBinders;
using uSwitch.MvcBrownBag.Web.Models;

namespace uSwitch.MvcBrownBag.Web.Core
{
	public class Bootstrapper
	{
		public Bootstrapper Configure()
		{
			Domain.NHibernate.Configuration.Setup();
			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(new ApplicationViewEngine());

            ModelBinders.Binders.Add(typeof(CreateArtistView), new CreateArtistViewModelBinder());

			ObjectFactory.Configure(x => x.AddRegistry<WebRegistry>());
			return this;
		}
	}
}