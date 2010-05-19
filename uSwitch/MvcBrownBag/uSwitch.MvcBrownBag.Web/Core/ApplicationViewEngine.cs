using System.Web.Mvc;

namespace uSwitch.MvcBrownBag.Web.Core
{
	public class ApplicationViewEngine : WebFormViewEngine
	{
		public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
		{
			if (!controllerContext.Controller.ControllerContext.IsChildAction)
			{
				var request = controllerContext.RequestContext.HttpContext.Request;

				if (request.Cookies["partner"] != null && request.Cookies["partner"].Value == "cobrand")
				{
					masterName = "~/Views/Shared/Cobrand.Master";
				}
			}

			return base.FindView(controllerContext, viewName, masterName, useCache);
		}
	}
}