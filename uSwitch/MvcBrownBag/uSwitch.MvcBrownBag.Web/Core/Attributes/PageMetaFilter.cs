using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uSwitch.MvcBrownBag.Web.Models;

namespace uSwitch.MvcBrownBag.Web.Attributes
{
    public class PageMetaFilterAttribute : FilterAttribute, IActionFilter
    {
        public string Title
        {
            get; set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Keywords
        {
            get;
            set;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var masterPageModel = MasterPageView.GetViewData(filterContext.Controller);
            masterPageModel.PageTitle = Title;
            masterPageModel.PageMetaDescription = Description;
            masterPageModel.PageMetaKeywords = Keywords;
        }
    }
}
