using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using LiveNation.ViewsPresentation.Models;
using LiveNation.ViewsPresentation.ViewEngine.ActionResult;

namespace LiveNation.ViewsPresentation.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
			var product = new Product { Id = 1, Name = "Jamie" };

			var view = View();
			view.ViewData.Add("id", product.Id);
			view.ViewData.Add("name", product.Name);

			return view;
        }

		public ProductResult ProductView()
		{
			var product = new Product { Id = 1, Name = "Jamie" };
			return new ProductResult(product);
		}
    }
}
