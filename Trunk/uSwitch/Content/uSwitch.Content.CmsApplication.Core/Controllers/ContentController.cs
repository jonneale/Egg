using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using uSwitch.Content.CmsApplication.Core.PresentationModel;

namespace uSwitch.Content.CmsApplication.Core.Controllers
{
	public class ContentController : Controller
	{
		[HttpGet]
		public ViewResult Create()
		{
			return View();
		}

		[HttpPost]
		public ViewResult Create(AddContentModel addContentModel)
		{
			return Redirect("content\all");
		}
	}
}
