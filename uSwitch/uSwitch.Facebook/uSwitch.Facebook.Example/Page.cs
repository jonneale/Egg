using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Facebook.API;

namespace uSwitch.FacebookApp.Example
{
	public class Page : System.Web.UI.Page
	{
		public Facebook.Extended.IFacebookConnect Facebook
		{
			get
			{
				return null;
			}
		}
	}
}
