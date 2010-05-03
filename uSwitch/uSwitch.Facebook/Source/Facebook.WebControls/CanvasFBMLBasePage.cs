using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using Facebook.Components;


namespace Facebook.WebControls
{
    public class CanvasFBMLBasePage : Page
    {
        Facebook.Components.FacebookService _fbService = new Facebook.Components.FacebookService();
        private const string SESSION_SESSION_KEY = "SessionKey";
        private const string SESSION_USER_ID = "UserId";
        private const string REQUEST_IN_CANVAS = "fb_sig_in_canvas";
        private const string REQUEST_SESSION_KEY = "fb_sig_session_key";
        private const string REQUEST_USER_ID = "fb_sig_user";
        private const string QUERY_AUTH_TOKEN = "auth_token";
        private const string FACEBOOK_LOGIN_URL = @"http://www.facebook.com/login.php?api_key=";
        private const string FACEBOOK_ADD_URL = @"http://www.facebook.com/add.php?api_key=";

        private string _api = null;
        private string _secret = null;
        private bool _autoAdd = true;

        public string Api
        {
            get { return _api; }
            set { _api = value; }
        }
        public string Secret
        {
            get { return _secret; }
            set { _secret = value; }
        }
        public bool AutoAdd
        {
            get { return _autoAdd; }
            set { _autoAdd = value; }
        }
        public Facebook.Components.FacebookService FBService
        {
            get { return _fbService; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string sessionKey = null;
            string userId = null;
            string inCanvas = Request[REQUEST_IN_CANVAS];

            // ApplicationKey and Secret are acquired when you sign up for 
            _fbService.ApplicationKey = _api;
            _fbService.Secret = _secret;
            _fbService.IsDesktopApplication = false;

            if (string.IsNullOrEmpty(_fbService.SessionKey) || string.IsNullOrEmpty(_fbService.UserId))
            {
                sessionKey = Request[REQUEST_SESSION_KEY];
                userId = Request[REQUEST_USER_ID];
            }
            else
            {
                sessionKey = _fbService.SessionKey;
                userId = _fbService.UserId;
            }

            // When the user uses the facebook login page, the redirect back here will will have the auth_token in the query params
            string authToken = Request.QueryString[QUERY_AUTH_TOKEN];

            // We have already established a session on behalf of this user
            if (!String.IsNullOrEmpty(sessionKey))
            {
                _fbService.SessionKey = sessionKey;
                _fbService.UserId = userId;
            }
            //// This will be executed when facebook login redirects to our page
            else if (!String.IsNullOrEmpty(authToken)) 
            {
                _fbService.CreateSession(authToken);
            }
            else
            {
                Response.Write("<fb:redirect url=\"" + FACEBOOK_LOGIN_URL + _fbService.ApplicationKey + @"&v=1.0" + "\"/>");
                Response.End();
            }

            if (!_fbService.IsAppAdded() && _autoAdd)
            {
                if ((!string.IsNullOrEmpty(inCanvas) && inCanvas.Equals("1")) || (!string.IsNullOrEmpty(Request.Url.ToString()) && Request.Url.ToString().ToLower().Contains("facebook.com")))
                {
                    Response.Write("<fb:redirect url=\"" + FACEBOOK_ADD_URL + _fbService.ApplicationKey + @"&v=1.0" + "\"/>");
                    Response.End();
                }
                else
                {
                    Response.Redirect(FACEBOOK_ADD_URL + _fbService.ApplicationKey + @"&v=1.0");
                }
            }        
        }
    }
}
