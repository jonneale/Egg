using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace uSwitch.SiteSpeed.Web.Core.Modules
{
	public class CacheModule : IHttpModule
	{
		public void Init(HttpApplication context)
		{
			context.PostRequestHandlerExecute += new EventHandler(context_PostRequestHandlerExecute);
		}

		void context_PostRequestHandlerExecute(object sender, EventArgs e)
		{
			// Wrapper for on HttpContext, testable (System.Web.Abstractions)
			var context = new HttpContextWrapper(HttpContext.Current);

			string extensions = Path.GetExtension(context.Request.Path);

			if (extensions.ToLowerInvariant().Contains("css") || extensions.ToLowerInvariant().Contains("js"))
			{
				TimeSpan cacheDuration = TimeSpan.FromDays(2);
				var expireTime = DateTime.Now.Add(cacheDuration);

				var response = context.Response;
				response.Cache.SetExpires(expireTime);
				response.Cache.SetCacheability(HttpCacheability.Private);
				response.Cache.SetMaxAge(cacheDuration);
				response.Cache.AppendCacheExtension("must-revalidate, proxy-revalidate");
			}
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
