using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace uSwitch.MvcBrownBag.Web.Controllers
{
    public class PartnerController : Controller
    {
        //
        // GET: /Partner/

        public ActionResult CreatePartner()
        {
			Response.Cookies.Add(new HttpCookie("partner", "cobrand"));
            return Redirect("~/artist");
        }

		public ActionResult RemovePartner()
		{
			var requestCookie = Request.Cookies["partner"];
			requestCookie.Expires = DateTime.Now.AddDays(-1);
			Response.Cookies.Add(requestCookie);

			return Redirect("~/artist");
		}

    }
}
