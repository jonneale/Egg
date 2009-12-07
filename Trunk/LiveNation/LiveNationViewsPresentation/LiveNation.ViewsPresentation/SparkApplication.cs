using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spark.Web.Mvc;
using System.Web.Mvc;

namespace LiveNation.ViewsPresentation
{
	public class SparkApplication : IMvcApplication
	{
		public void RegisterViewEngines()
		{
			//if (engines == null) throw new ArgumentNullException("engines");
			ViewEngines.Engines.Clear();
			SparkEngineStarter.RegisterViewEngine(ViewEngines.Engines);
		}
	}
}
