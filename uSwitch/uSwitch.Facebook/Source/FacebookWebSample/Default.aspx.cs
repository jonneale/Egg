using System;
using System.Collections.ObjectModel;
using System.Web.UI;
using Facebook.Entity;
using Facebook.WebControls;

public partial class _Default : Page 
{
    Facebook.Components.FacebookService _fbService = new Facebook.Components.FacebookService();

    private const string FACEBOOK_API_KEY = "7a399eeba47b0f5b2bfd88cc872ada4a";
    private const string FACEBOOK_SECRET = "fad3d3fbeb8571957c39e2792073b978";


    protected void Page_Load(object sender, EventArgs e)
    {
        
        // ApplicationKey and Secret are acquired when you sign up for 
        _fbService.ApplicationKey = FACEBOOK_API_KEY;
        _fbService.Secret = FACEBOOK_SECRET;
        _fbService.IsDesktopApplication = false;

        string sessionKey = Session["facebook_session_key"] as String;
        string userId = Session["facebook_userId"] as String;

        // When the user uses the facebook login page, the redirect back here will will have the auth_token in the query params
        string authToken = Request.QueryString["auth_token"];

        // We have already established a session on behalf of this user
        if (!String.IsNullOrEmpty(sessionKey))
        {
            _fbService.SessionKey = sessionKey;
            _fbService.UserId = userId;
        }
        // This will be executed when facebook login redirects to our page
        else if (!String.IsNullOrEmpty(authToken)) 
        {
            _fbService.CreateSession(authToken);
            Session["facebook_session_key"] = _fbService.SessionKey;
            Session["facebook_userId"] = _fbService.UserId;
            Session["facebook_session_expires"] = _fbService.SessionExpires;
        }
        // Need to login
        else 
        {
            Response.Redirect(@"http://www.facebook.com/login.php?api_key=" + _fbService.ApplicationKey + @"&v=1.0");
        }

        if (!IsPostBack)
        {
            // Use the FacebookService Component to populate Friends
            MyFriendList.Friends = _fbService.GetFriends();
        }

        MyPhotoAlbum.FacebookService = _fbService;

    }

    protected void MyFriendList_FriendClick(object sender, FriendListItemClickEventArgs e)
    {
        string userId = e.FriendId;
        Collection<User> users = _fbService.GetUserInfo(userId);
        if (users.Count > 0)
        {
            MyUserProfile.User = users[0];
            MyPhotoAlbum.LoadAlbums(_fbService, userId);
            
        }
        
    }
}
