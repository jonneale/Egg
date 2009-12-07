using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.ObjectModel;
using Facebook;
using Facebook.WebControls;

public partial class Silverlight : CanvasIFrameBasePage 
{
    private const string FACEBOOK_API_KEY = "c559128010f3edee33796fd4205361c2";
    private const string FACEBOOK_SECRET = "85887d1c9a8334e5059742468a5400ee";

    new protected void Page_Load(object sender, EventArgs e)
    {
        base.Api = FACEBOOK_API_KEY;
        base.Secret = FACEBOOK_SECRET;
        base.Page_Load(sender, e);
        hidAPI.Value = this.FBService.ApplicationKey;
        hidSecret.Value = this.FBService.Secret;
        hidSession.Value = this.FBService.SessionKey;
        hidUser.Value = this.FBService.UserId;
    }
}
