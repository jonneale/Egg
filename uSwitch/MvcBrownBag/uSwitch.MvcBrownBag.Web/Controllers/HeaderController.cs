using System;
using System.Web.Mvc;
using System.Web.UI;
using uSwitch.MvcBrownBag.Web.Models;

namespace uSwitch.MvcBrownBag.Web.Controllers
{
	public class HeaderController : Controller
	{
        //[OutputCache(Duration = 60, VaryByParam = "None", Location = OutputCacheLocation.Server)]
		public ViewResult Show()
		{
			return View(new HeaderView { LastUpdated = DateTime.Now, LoginName = string.Empty} );
		}
	}
}