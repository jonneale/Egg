using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using Facebook.Components;


namespace Facebook.WebControls
{
    public class CanvasIFrameBasePage : Page
    {
        Facebook.Components.FacebookService _fbService = new Facebook.Components.FacebookService();
        private const string SESSION_SESSION_KEY = "SessionKey";
        private const string SESSION_USER_ID = "UserId";
        private const string REQUEST_SESSION_KEY = "fb_sig_session_key";
        private const string REQUEST_USER_ID = "fb_sig_user";
        private const string REQUEST_IN_CANVAS = "fb_sig_in_canvas";
        private const string QUERY_AUTH_TOKEN = "auth_token";
        private const string FACEBOOK_LOGIN_URL = @"http://www.facebook.com/login.php?api_key=";
        private const string FACEBOOK_ADD_URL = @"http://www.facebook.com/add.php?api_key=";

        private string _api = null;
        private string _secret = null;
        private bool _useSession = true;
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
        public bool UseSession
        {
            get { return _useSession; }
            set { _useSession = value; }
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

        protected override void OnPreRender(EventArgs e)
        {
            Response.AppendHeader("P3P", "CP=\"CAO PSA OUR\"");
            base.OnPreRender(e);
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
            if (_useSession)
            {
                if (String.IsNullOrEmpty(sessionKey) && Session[SESSION_SESSION_KEY] != null)
                {
                    sessionKey = Session[SESSION_SESSION_KEY].ToString();
                    userId = Session[SESSION_USER_ID].ToString();
                }

                if (!String.IsNullOrEmpty(sessionKey))
                {
                    _fbService.SessionKey = sessionKey;
                    _fbService.UserId = userId;
                    Session[SESSION_SESSION_KEY] = sessionKey;
                    Session[SESSION_USER_ID] = userId;
                }
                //// This will be executed when facebook login redirects to our page
                else if (!String.IsNullOrEmpty(authToken))
                {
                    _fbService.CreateSession(authToken);
                    Session[SESSION_SESSION_KEY] = _fbService.SessionKey;
                    Session[SESSION_USER_ID] = _fbService.UserId;
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">\nif (parent != self) \ntop.location.href = \"" + FACEBOOK_LOGIN_URL + _fbService.ApplicationKey + @"&v=1.0" + "\";\nelse self.location.href = \"" + FACEBOOK_LOGIN_URL + _fbService.ApplicationKey + @"&v=1.0" + "\";\n</script>");
                    Response.End();
                    return;
                }

                if (!_fbService.IsAppAdded() && _autoAdd)
                {
                    if (_fbService.SessionKey != null)
                    {
                        Session[SESSION_SESSION_KEY] = null;
                        Session[SESSION_USER_ID] = null;
                        Response.Write("<script type=\"text/javascript\">\nif (parent != self) \ntop.location.href = \"" + FACEBOOK_ADD_URL + _fbService.ApplicationKey + @"&v=1.0" + "\";\nelse self.location.href = \"" + FACEBOOK_ADD_URL + _fbService.ApplicationKey + @"&v=1.0" + "\";\n</script>");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">\nif (parent != self) \ntop.location.href = \"" + FACEBOOK_LOGIN_URL + _fbService.ApplicationKey + @"&v=1.0" + "\";\nelse self.location.href = \"" + FACEBOOK_LOGIN_URL + _fbService.ApplicationKey + @"&v=1.0" + "\";\n</script>");
                        Response.End();
                    }
                }
            }
            else
            {
                if (String.IsNullOrEmpty(sessionKey) && Request.Cookies[SESSION_SESSION_KEY] != null)
                {
                    sessionKey = Request.Cookies[SESSION_SESSION_KEY].Value;
                    userId = Request.Cookies[SESSION_USER_ID].Value;
                }

                if (!String.IsNullOrEmpty(sessionKey))
                {
                    _fbService.SessionKey = sessionKey;
                    _fbService.UserId = userId;
                    Response.Cookies.Clear();
                    Response.Cookies.Add(new HttpCookie(SESSION_SESSION_KEY, sessionKey));
                    Response.Cookies.Add(new HttpCookie(SESSION_USER_ID, userId));
                }
                //// This will be executed when facebook login redirects to our page
                else if (!String.IsNullOrEmpty(authToken))
                {
                    _fbService.CreateSession(authToken);
                    Response.Cookies.Clear();
                    Response.Cookies.Add(new HttpCookie(SESSION_SESSION_KEY, sessionKey));
                    Response.Cookies.Add(new HttpCookie(SESSION_USER_ID, userId));
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">\nif (parent != self) \ntop.location.href = \"" + FACEBOOK_LOGIN_URL + _fbService.ApplicationKey + @"&v=1.0" + "\";\nelse self.location.href = \"" + FACEBOOK_LOGIN_URL + _fbService.ApplicationKey + @"&v=1.0" + "\";\n</script>");
                    Response.End();
                    return;
                }

                if (!_fbService.IsAppAdded() && _autoAdd)
                {
                    if (_fbService.SessionKey != null)
                    {
                        Response.Cookies.Clear();
                        Response.Write("<script type=\"text/javascript\">\nif (parent != self) \ntop.location.href = \"" + FACEBOOK_ADD_URL + _fbService.ApplicationKey + @"&v=1.0" + "\";\nelse self.location.href = \"" + FACEBOOK_ADD_URL + _fbService.ApplicationKey + @"&v=1.0" + "\";\n</script>");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">\nif (parent != self) \ntop.location.href = \"" + FACEBOOK_LOGIN_URL + _fbService.ApplicationKey + @"&v=1.0" + "\";\nelse self.location.href = \"" + FACEBOOK_LOGIN_URL + _fbService.ApplicationKey + @"&v=1.0" + "\";\n</script>");
                        Response.End();
                    }
                }
            }
        }
    }
}
