using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uSwitch.MvcBrownBag.Web.Attributes;

namespace uSwitch.MvcBrownBag.Web.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
        [PageMetaFilter(Description = "The home page", Title = "I'm the home page")]
		public ActionResult Index()
		{
			ViewData["Message"] = "Welcome to ASP.NET MVC!";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
