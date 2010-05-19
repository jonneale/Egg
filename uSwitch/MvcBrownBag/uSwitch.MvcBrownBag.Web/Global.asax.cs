using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;
using uSwitch.MvcBrownBag.Web.Core;
using Bootstrapper=uSwitch.MvcBrownBag.Web.Core.Bootstrapper;

namespace uSwitch.MvcBrownBag.Web
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

			routes.MapRoute(
				"Detail", // Route name
				"{controller}/{id}", // URL with parameters
				new { controller = "Home", action = "Detail" } // Parameter defaults
			);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterRoutes(RouteTable.Routes);

			new Bootstrapper().Configure();

			ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
		}

		protected void Application_EndRequest()
		{
			ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
		}
	}
}