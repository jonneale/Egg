using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiveNation.ViewsPresentation.ViewEngine;
using System.Web.Mvc;

namespace LiveNation.ViewsPresentation
{
	public class SimpleApplication : IMvcApplication
	{
		public void RegisterViewEngines()
		{
			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(new SimpleViewEngine());
		}
	}
}
