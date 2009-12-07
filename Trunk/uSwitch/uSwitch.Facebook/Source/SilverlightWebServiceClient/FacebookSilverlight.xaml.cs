using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;
using System.Windows.Browser.Net;
using System.Xml;
using System.IO;
using System.Net;
using System.Collections.Generic;
namespace SilverlightWebServiceClient
{
    public partial class FacebookSilverlight : Canvas
    {
        private HtmlElement _hidApi;
        private HtmlElement _hidSecret;
        private HtmlElement _hidSession;
        private HtmlElement _hidUser;
        
        public void Page_Loaded(object o, EventArgs e)
        {
            // Required to initialize variables
            InitializeComponent();

            Canvas c = o as Canvas;
            _hidApi = HtmlPage.Document.GetElementByID("hidAPI");
            _hidSecret = HtmlPage.Document.GetElementByID("hidSecret");
            _hidSession = HtmlPage.Document.GetElementByID("hidSession");
            _hidUser = HtmlPage.Document.GetElementByID("hidUser");

            facebookProxy.UserJSON[] friends = CallWS(_hidApi.GetProperty<string>("Value"), _hidSecret.GetProperty<string>("Value"), _hidSession.GetProperty<string>("Value"), _hidUser.GetProperty<string>("Value"));

            tb.Text = "You have " + friends.Length + " friends.";//CallWS(_hidApi.GetProperty<string>("Value"), _hidSecret.GetProperty<string>("Value"), _hidSession.GetProperty<string>("Value"), _hidUser.GetProperty<string>("Value"));
        }



        private facebookProxy.UserJSON[] CallWS(string api, string secret, string session, string userid)
        {

            tb.Text = string.Empty;
            status.Text = string.Empty;

            //call a web service.
            facebookProxy.SilverlightService service1 = new facebookProxy.SilverlightService();
            try
            {
                facebookProxy.UserJSON[] x= service1.GetFriends(api, secret, session, userid);
                return x;
            }
            catch (Exception ex)
            {
                status.Text = ex.Message;
                return null;
            }
        }

    }
}
