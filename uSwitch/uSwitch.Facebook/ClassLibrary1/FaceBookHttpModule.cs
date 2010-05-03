using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Facebook.Entity;
using System.Collections;

namespace Facebook.Extended
{
	public class FacebookHttpModule : IHttpModule
	{
		private FacebookConfig _config;
		private event EventHandler _preAuthenication;

		public event EventHandler PreAuthenication
		{
			add
			{
				_preAuthenication += value;
			}
			remove
			{
				_preAuthenication -= value;
			}
		}

		public void Init(HttpApplication context)
		{
			context.PreRequestHandlerExecute += new EventHandler(Context_PreRequestHandlerExecute);

			_config = FacebookConfig.GetConfig();
		}

		protected virtual void CacheApi(IFacebookApi api, IDictionary collection)
		{
			collection.Add("Facebook.Extended.IFacebookApi", api);
		}

		protected virtual void CacheFacebookConnect(IFacebookConnect facebookConnect, IDictionary collection)
		{
			collection.Add("Facebook.Extended.IFacebookConnect", facebookConnect);
		}

		protected virtual void OnPreAuthenication(object sender, EventArgs e)
		{
			HttpApplication application = sender as HttpApplication;
			IFacebookApi api = new FacebookApi();
			bool authenicated = false;

			IHttpAuthenication authenication = new HttpAuthenication(_config, application.Context.Request);

			if (authenication.IsConnected())
			{
				authenication.Authenicate(api);
				authenicated = true;
			}

			IFacebookConnect connect = new FacebookConnect(api, authenicated);

			CacheApi(api, application.Context.Items);
			CacheFacebookConnect(connect, application.Context.Items);
		}

		private void Context_PreRequestHandlerExecute(object sender, EventArgs e)
		{
			OnPreAuthenication(sender, e);
		}

		public void Dispose()
		{

		}
	}
}
