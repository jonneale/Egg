using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace uSwitch.FacebookApp.Example
{
	public partial class LoginDetails : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//Page basePage = (Page)Page;
			//if (basePage.LoggedIntoFacebook)
			//{
			//    Facebook.Entity.User user = basePage.FaceBookApi.GetUserInfo();
			//    NameLabel.Text = string.Concat(user.FirstName, " ", user.LastName);
			//    AgeLabel.Text = user.Birthday.HasValue ? user.Birthday.Value.ToShortDateString() : string.Empty;
			//    AboutMeLabel.Text = user.AboutMe;
			//    Visible = true;
			//}
			//else
			//{
			//    Visible = false;
			//}
		}
	}
}