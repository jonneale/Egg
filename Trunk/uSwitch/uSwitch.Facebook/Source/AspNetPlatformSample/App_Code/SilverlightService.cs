using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.Script.Services;
using System.Xml;



/// <summary>
/// Summary description for Service1
/// </summary>
/// <summary>
/// Notice in the class declaration below that the class has been assigned the ScriptService
/// attribute.  This is required to allow your web service be called from scripting clients
/// such as Silverlight.
/// </summary>
[WebService(Namespace = "http://facebook.claritycon.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class SilverlightService : System.Web.Services.WebService
{
    Facebook.Components.FacebookService _fbService = new Facebook.Components.FacebookService();


    [WebMethod]
    public UserJSON[] GetFriends(string api, string secret, string session, string userid)
    {
        _fbService.ApplicationKey = api;
        _fbService.Secret = secret;
        _fbService.SessionKey = session;
        _fbService.UserId = userid;
        Collection<Facebook.Entity.User> friends = _fbService.GetFriends();
        UserJSON[] x = UserJSON.ConvertFacebookUserArray(friends);
        return x;
    }


}
