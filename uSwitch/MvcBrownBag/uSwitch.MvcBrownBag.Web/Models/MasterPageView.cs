using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace uSwitch.MvcBrownBag.Web.Models
{
    public class MasterPageView
    {
        public string PageTitle
        {
            get; set;
        }

        public string PageMetaDescription
        {
            get;
            set;
        }

        public string PageMetaKeywords
        {
            get;
            set;
        }

        public static MasterPageView GetViewData(ControllerBase controller)
        {
            MasterPageView model = null;

            if (controller.ViewData["MasterPage"] == null)
            {
                model = new MasterPageView();
                controller.ViewData["MasterPage"] = model;
            } else
            {
                model = controller.ViewData["MasterPage"] as MasterPageView;
            }

            return model;
        }
    }
}
