using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Web.Mvc;
using Castle.Windsor;
using System.Web.

namespace uSwitch.Content.CmsApplication.Core.Controllers
{
	public class WindsorControllerFactory : IControllerFactory
	{

		readonly IWindsorContainer container;

		public WindsorControllerFactory(IWindsorContainer container)
		{
			this.container = container;
		}


		public IController CreateController(RequestContext requestContext, string controllerName)
		{
			throw new NotImplementedException();
		}

		public void ReleaseController(IController controller)
		{
			container.Release(controller);
		}

		/// <returns>Name of the controller component.</returns>
		static string GetComponentNameFromControllerName(string controllerName)
		{
			var controllerNamespace = typeof(HomeController).Namespace;
			return string.Format("{0}.{1}Controller", controllerNamespace, controllerName);
		}
	}
}
