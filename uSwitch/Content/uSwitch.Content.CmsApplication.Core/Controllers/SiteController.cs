using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace uSwitch.Content.CmsApplication.Core.Controllers
{
	public class SiteController : Controller
	{
		public ActionResult Display(string siteName)
		{
			return View();
		}
	}
}
