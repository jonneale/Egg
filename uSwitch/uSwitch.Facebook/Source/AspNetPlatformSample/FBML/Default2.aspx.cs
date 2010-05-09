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

public partial class Default2 : CanvasFBMLBasePage
{
    private const string FACEBOOK_API_KEY = "e739cf9a3580497cbbd7e6e4e98f7627";
    private const string FACEBOOK_SECRET = "f6184d3fdab6d99baa018e3f61db7f77";

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
            }
            catch (Exception ee)
            {
                Response.Write(ee.Message);
                Response.End();
                throw;
            }
        }
    }
}