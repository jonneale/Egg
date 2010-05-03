using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Xml;
using System.IO;
using System.Web.UI;
using Facebook.Components;
using System.Web;
using System.Collections.ObjectModel;
using Facebook;
using Facebook.Exceptions;
using Facebook.Entity;
using Facebook.API;
using System.Xml.Linq;

namespace Facebook.Extended
{
	public class FacebookApi : FacebookAPI, IFacebookApi
	{
		public XDocument ExecuteApiRequest(IDictionary<string, string> parameterDictionary, bool useSession)
		{
			string xmlString = ExecuteApiCallString(parameterDictionary, useSession);
			return XDocument.Parse(xmlString);
		}

		public static IFacebookApi GetCurrent(HttpContext context)
		{
			return context.Items["FaceBookService"] as IFacebookApi;
		}

		private Dictionary<string, string> BuildQueryString(string method)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters["method"] = method;
			parameters["session_key"] = this.SessionKey;
			return parameters;
		}

		public void SetProfile(string userID, string titleName)
		{
			StringBuilder builder = new StringBuilder();
			TextWriter textWriter = new StringWriter(builder);
			FBMLWriter writer = new FBMLWriter(textWriter);
			writer.RenderBeginTag(FBMLTag.Wide);
			writer.RenderBeginTag(FBMLTag.Title);
			writer.Write(titleName);
			writer.RenderEndTag();
			writer.WriteLine("I hope this works");
			writer.RenderEndTag();

			Dictionary<string, string> parameters = BuildQueryString("profile.setFBML");
			parameters["markup"] = builder.ToString();
			XmlDocument responseDoc = RestService.Request(parameters);
		}

		public void SendInvite(StringCollection recipients, string notificationFBML, string emailFBML)
		{

		}

		private XmlDocument LoadXMLDocument(string rawXML)
		{
			XmlDocument doc = new XmlDocument();
			XmlNamespaceManager manager = new XmlNamespaceManager(doc.NameTable);
			manager.AddNamespace("Facebook", "FacebookNamespace=http://api.facebook.com/1.0/");
			doc.LoadXml(rawXML);
			return doc;
		}

		//public Collection<User> GetUserInfoAlternative(string userIds)
		//{
		//    Collection<User> collection = new Collection<User>();
		//    string userInfoXml = this.GetUserInfoXml(userIds);
		//    if (!userInfoXml.Equals(string.Empty))
		//    {
		//        XmlDocument document = this.LoadXMLDocument(userInfoXml);
		//        if (!document.GetElementsByTagName("fql_query_response")[0].HasChildNodes)
		//        {
		//            return collection;
		//        }
		//        XmlNodeList elementsByTagName = document.GetElementsByTagName("user");
		//        foreach (XmlNode node in elementsByTagName)
		//        {
		//            collection.Add(UserParser.ParseUser(node));
		//        }
		//    }
		//    return collection;
		//}

		//public Collection<User> GetFriendsAlternative()
		//{
		//    Collection<User> userInfo = new Collection<User>();
		//    string friendsXML = this.GetFriendsXML();
		//    if (!friendsXML.Equals(string.Empty))
		//    {
		//        XmlDocument document = this.LoadXMLDocument(friendsXML);
		//        if (!document.GetElementsByTagName("fql_query_response")[0].HasChildNodes)
		//        {
		//            throw new FacebookException("Friends: XML returned by Facebook is empty!");
		//        }
		//        XmlNodeList elementsByTagName = document.GetElementsByTagName("friend_info");
		//        Collection<string> collection2 = new Collection<string>();
		//        if (elementsByTagName.Count <= 0)
		//        {
		//            return userInfo;
		//        }
		//        foreach (XmlNode node in elementsByTagName)
		//        {
		//             XmlElement element = node as XmlElement;
		//             if ((node != null) && (element.GetElementsByTagName("uid2").Count > 0))
		//             {
		//                 collection2.Add(element.GetElementsByTagName("uid2")[0].InnerText);
		//             }
		//        }
		//        StringBuilder userIdCommaStr = new StringBuilder();

		//        bool firstLoop = true;
		//        foreach (string nodeText in collection2)
		//        {
		//            if (firstLoop)
		//            {
		//                firstLoop = false;
		//            }
		//            else
		//            {
		//                userIdCommaStr.Append(",");
		//            }

		//            userIdCommaStr.Append(nodeText);
		//        }

		//        userInfo = this.GetUserInfoAlternative(userIdCommaStr.ToString());
		//    }
		//    return userInfo;
		//}



		public XmlDocument GetNotifications()
		{
			Dictionary<string, string> parameters = BuildQueryString("notifications.get");
			XmlDocument responseDoc = RestService.Request(parameters);
			return responseDoc;
		}

		public void SendNotification(INotification notification)
		{
			FacebookConfig config = FacebookConfig.GetConfig();

			if (config.EnableNotifications)
			{
				Dictionary<string, string> parameters = BuildQueryString("notifications.send");
				parameters["notification"] = notification.BodyMarkup;
				if (!string.IsNullOrEmpty(notification.EmailMarkup))
				{
					parameters["email"] = notification.EmailMarkup;
				}

				string[] recipientsArray = new string[notification.UserIds.Count];
				notification.UserIds.CopyTo(recipientsArray, 0);
				parameters["to_ids"] = String.Join(",", recipientsArray);

				XmlDocument responseDoc = RestService.Request(parameters);
			}
		}

		public void PublishStoryFeed(string title, string body, System.Collections.Specialized.StringDictionary images)
		{
			//images variable contains the image url (key) and click url (value)
			Dictionary<string, string> parameters = BuildQueryString("feed.publishStoryToUser");
			parameters["title"] = title;
			parameters["body"] = body;

			int counter = 1;
			foreach (KeyValuePair<string, string> pair in images)
			{
				parameters[string.Concat("image_", counter)] = pair.Key;
				parameters[string.Concat("image_", counter, "_link")] = pair.Value;
			}
			XmlDocument responseDoc = RestService.Request(parameters);
		}

		public void PublishMiniFeed(string title, string body, System.Collections.Specialized.StringDictionary images)
		{
			//images variable contains the image url (key) and click url (value)
			Dictionary<string, string> parameters = BuildQueryString("feed.publishActionOfUser");
			parameters["title"] = title;
			parameters["body"] = body;

			int counter = 1;
			foreach (KeyValuePair<string, string> pair in images)
			{
				parameters[string.Concat("image_", counter)] = pair.Key;
				parameters[string.Concat("image_", counter, "_link")] = pair.Value;
			}
			XmlDocument responseDoc = RestService.Request(parameters);
		}
	}
}
