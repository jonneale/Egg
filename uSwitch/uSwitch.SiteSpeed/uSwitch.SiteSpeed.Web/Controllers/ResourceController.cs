using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace uSwitch.SiteSpeed.Web.Controllers
{
    public class ResourceController : Controller
    {
        public ActionResult Index()
        {
        	return View("lotsofcalls");
        }

		[OutputCache(Location = OutputCacheLocation.Server, Duration = 3600, VaryByParam = "theParameter")]
		public ActionResult Cached(string theParameter)
		{
			ViewData["LastModified"] = DateTime.Now;

			return View("serveroutputcaching");
		}
    }
}
