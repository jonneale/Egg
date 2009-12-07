using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.ObjectModel;
using Facebook;
using Facebook.WebControls;

public partial class Default2 : CanvasIFrameBasePage
{
    private const string FACEBOOK_API_KEY = "c559128010f3edee33796fd4205361c2";
    private const string FACEBOOK_SECRET = "85887d1c9a8334e5059742468a5400ee";

    new protected void Page_Load(object sender, EventArgs e)
    {
        base.Api = FACEBOOK_API_KEY;
        base.Secret = FACEBOOK_SECRET;
        base.Page_Load(sender, e);

        if (!IsPostBack)
        {
            try
            {
                // Use the FacebookService Component to populate Friends
                Facebook.Entity.User u = this.FBService.GetUserInfo();
                Collection<Facebook.Entity.User> f = this.FBService.GetFriends();

                string s = "";
                if (f.Count != 1)
                {
                    s = "s";
                }
                lblHelloWorld.Text = "Hello " + u.Name + " you have " + f.Count + " friend" + s + "..." + this.FBService.SessionKey;
                this.FBService.SetFBML("Hello " + u.Name + " you have " + f.Count + " friend" + s);
                //Dictionary<string, Uri> images = new Dictionary<string, Uri>();
                //images.Add("image_1", new Uri("http://facebook.claritycon.com/CarmenWithCarter.jpg"));
                //this.FBService.PublishAction("Birth Announcements2", "Birth Announcement Sent2", images);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
