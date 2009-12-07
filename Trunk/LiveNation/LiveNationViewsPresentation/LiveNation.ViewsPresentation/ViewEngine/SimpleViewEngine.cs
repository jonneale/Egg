using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiveNation.ViewsPresentation.ViewEngine.Views;

namespace LiveNation.ViewsPresentation.ViewEngine
{
	public class SimpleViewEngine : VirtualPathProviderViewEngine
	{
		private const string _viewPath = "~/Views/{1}/{0}.htm";
		private const string _sharedViewPath = "~/Views/{1}/{0}.htm";

		public SimpleViewEngine()  
        {
			this.ViewLocationFormats = new string[] { _viewPath };
			this.PartialViewLocationFormats = new string[] { _sharedViewPath };  
        }  
  
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)  
        {  
            var physicalPath = controllerContext.HttpContext.Server.MapPath(viewPath);  
            return new SimpleView(physicalPath);  
        }  
  
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)  
        {  
            var physicalPath = controllerContext.HttpContext.Server.MapPath(partialPath);  
            return new SimpleView(physicalPath);  
        }  
	}
}
