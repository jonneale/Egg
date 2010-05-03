using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook.Extended;
using System.Xml.Linq;

namespace uSwitch.FacebookApp.Example
{
	public partial class registerusers : System.Web.UI.Page
	{
		protected FacebookConnect FaceBook;

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			FaceBook = (FacebookConnect)FacebookConnect.GetCurrent(HttpContext.Current.Items);

			registerSteveButton.Click += new EventHandler(RegisterSteve_ClickEvent);
			registerGeneraluSwitch.Click += new EventHandler(RegisterGeneraluSwitch_ClickEvent);
		}

		protected void RegisterGeneraluSwitch_ClickEvent(object sender, EventArgs e)
		{
			ICollection<string> emails = new List<string> 
			{ 
				"jasonglynn@gmail.com",
				"rossrosser@hotmail.com",
				"iluvmaxx666@yahoo.com",
				"markholdsworth@gmail.com"
			};
			ICollection<string> registeredLists = FaceBook.RegisterUsers(emails);

			statusLabel.Text = string.Empty;
			foreach (string emailHash in registeredLists)
			{
				statusLabel.Text += " " + emailHash;
			}
			
			
		}

		protected void RegisterSteve_ClickEvent(object sender, EventArgs args)
		{
			ICollection<string> emails = new List<string> { "steve.williamson@gmail.com" };
			ICollection<string> registeredLists = FaceBook.RegisterUsers(emails);
			statusLabel.Text = registeredLists.Single();
		}
	}
}
