using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Facebook.Extended
{
	public class FacebookScriptLoader
	{
		private Page _page;

		public FacebookScriptLoader(Page page)
		{
			_page = page;

			_page.PreRender += new EventHandler(_page_PreRender);
		}

		void _page_PreRender(object sender, EventArgs e)
		{
			var script = new HtmlGenericControl("script");
			script.Attributes.Add("src", "http://static.ak.connect.facebook.com/js/api_lib/v0.4/FeatureLoader.js.php");
			script.Attributes.Add("type", "text/javascript");

			_page.Form.Controls.Add(script);
		}
	}
}
