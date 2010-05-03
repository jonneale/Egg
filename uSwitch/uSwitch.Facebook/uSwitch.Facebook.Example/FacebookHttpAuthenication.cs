using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace uSwitch.FacebookApp.Example
{
	public class FacebookHttpAuthenication
	{
		protected HttpCookieCollection Cookies;

		public string ApiKey
		{
			get
			{
				return ConfigurationManager.AppSettings["uSwitch.FacebookConnect.API"];
			}
		}
		public string SecretKey 
		{
			get
			{
				return ConfigurationManager.AppSettings["uSwitch.FacebookConnect.Secret"];
			}
		}

		public string SessionKey
		{
			get
			{
				return GetFacebookCookie("session_key");
			}
		}

		public int UserID
		{
			get
			{
				int userID = -1;
				int.TryParse(GetFacebookCookie("user"), out userID); return userID;
			}
		}

		public FacebookHttpAuthenication(HttpCookieCollection cookies)
		{
			Cookies = cookies;
		}

		public bool isConnected()  
		{  
			return (SessionKey != null && UserID != -1);  
		}  

		private string GetFacebookCookie(string cookieName)
		{
			string retString = null;
			string fullCookie = ApiKey + "_" + cookieName;
			if (Cookies[fullCookie] != null)
			{
				retString = HttpContext.Current.Request.Cookies[fullCookie].Value;
			}

			return retString;
		}
	}
}
