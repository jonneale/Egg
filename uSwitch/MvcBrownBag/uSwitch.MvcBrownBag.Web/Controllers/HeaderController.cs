using System;
using System.Web.Mvc;
using System.Web.UI;
using uSwitch.MvcBrownBag.Web.Models;

namespace uSwitch.MvcBrownBag.Web.Controllers
{
	public class HeaderController : Controller
	{
		public ViewResult Show()
		{
		    var isLoggedIn = true;
            var model = new HeaderView { LastUpdated = DateTime.Now, LoginName = string.Empty };

            if (isLoggedIn)
            {
                return View("LoggedIn", model);
            }

            return View(model);
		}
	}
}