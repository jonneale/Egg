using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook.Entity;
using Facebook.Extended;

namespace uSwitch.FacebookApp.Example
{
	public partial class ProcessPage : Page
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			ContinueButton.Click += ContinueButton_Click;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				IFacebookConnect facebookConnect = FacebookConnect.GetCurrent(HttpContext.Current.Items);

				if (facebookConnect.Authenicated)
				{
					Facebook.Entity.User user = facebookConnect.CurrentUser;

					FirstNameText.Text = user.FirstName;
					LastNameText.Text = user.LastName;
					if (user.Sex != Gender.Unknown)
					{
						SexRadio.SelectedValue = (user.Sex == Gender.Male) ? "m" : "f";
					}

					DOBText.Text = user.Birthday.HasValue ? user.Birthday.Value.ToShortDateString() : string.Empty;
				}
			}
		}

		protected void ContinueButton_Click(object sender, EventArgs e)
		{
			Response.Redirect("/thankyou.aspx");
		}
	}
}
