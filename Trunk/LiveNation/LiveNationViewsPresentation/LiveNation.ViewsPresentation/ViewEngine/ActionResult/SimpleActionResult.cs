using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiveNation.ViewsPresentation.Models;

namespace LiveNation.ViewsPresentation.ViewEngine.ActionResult
{
	public class ProductResult : System.Web.Mvc.ActionResult
	{
		private Product _product;

		public ProductResult(Product product)
		{
			_product = product;
		}

		public override void ExecuteResult(System.Web.Mvc.ControllerContext context)
		{
			//context.HttpContext.Response.
		}
	}
}
