using System.Web.UI;
using uSwitch.MvcBrownBag.Web.Models;

namespace uSwitch.MvcBrownBag.Web.Core.DataBinders
{
    public class CreateArtistViewModelBinder : System.Web.Mvc.DefaultModelBinder
    {
        protected override object CreateModel(System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext, System.Type modelType)
        {
            var eventView =
                base.CreateModel(controllerContext, bindingContext, modelType) as CreateArtistView;

            return eventView;
        }
    }
}