using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Facebook.Extended;

namespace Facebook.Extended
{
	public class HttpAuthenication : IHttpAuthenication
	{
		protected HttpCookieCollection Cookies;

		protected FacebookConfig Config
		{
			get;
			private set;
		}

		protected HttpRequest Request
		{
			get;
			private set;
		}

		public string ApplicationKey
		{
			get
			{
				return Config.ApplicationKey;
			}
		}
		public string SecretKey 
		{
			get
			{
				return Config.SecretKey;
			}
		}

		public string CookieSessionKey
		{
			get
			{
				return GetFacebookCookie("session_key");
			}
		}

		public int CookieUserID
		{
			get
			{
				int userID = -1;
				int.TryParse(GetFacebookCookie("user"), out userID); 
				return userID;
			}
		}

		public HttpAuthenication(FacebookConfig config, HttpRequest request)
		{
			Request = request;
			Cookies = request.Cookies;
			Config = config;
		}

		public bool IsConnected()  
		{
			return (CookieSessionKey != null && CookieUserID != -1);  
		}

		public void Authenicate(IFacebookApi api)
		{
			if (IsConnected())
			{
				api.SessionKey = CookieSessionKey;
				api.Secret = SecretKey;
				api.ApplicationKey = ApplicationKey;
				api.UserId = CookieUserID.ToString();
			}
		}	

		private string GetFacebookCookie(string cookieName)
		{
			string retString = null;
			string fullCookie = ApplicationKey + "_" + cookieName;
			if (Cookies[fullCookie] != null)
			{
				retString = Request.Cookies[fullCookie].Value;
			}

			return retString;
		}
	}
}
