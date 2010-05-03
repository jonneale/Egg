using System;
using System.Globalization;
using System.Xml;
using Facebook.Utility;

namespace Facebook
{
    internal sealed class GroupParser
    {
        /// <summary>
        /// default constructor
        /// </summary>
        private GroupParser() { }

        /// <summary>
        /// Uses DOM parsing to constitute a Group data object given the xml returned from facebook
        /// </summary>
        internal static Group ParseGroup(XmlNode node)
        {
            Group group = new Group();
            if (node != null)
            {
                group.GroupId = XmlHelper.GetNodeText(node, "gid");
                group.Name = XmlHelper.GetNodeText(node, "name");
                group.NetworkId = XmlHelper.GetNodeText(node, "nid");
                group.Type = XmlHelper.GetNodeText(node, "group_type");
                group.SubType = XmlHelper.GetNodeText(node, "group_subtype");
                group.RecentNews = XmlHelper.GetNodeText(node, "recent_news");
                if(!String.IsNullOrEmpty(XmlHelper.GetNodeText(node, "pic")))
                {
                    group.PictureUrl = new Uri(XmlHelper.GetNodeText(node, "pic"));
                }
                group.Creator = XmlHelper.GetNodeText(node, "creator");
                if (!String.IsNullOrEmpty(XmlHelper.GetNodeText(node, "update_time")))
                {
                    group.UpdateDate = DateHelper.ConvertDoubleToDate(double.Parse(XmlHelper.GetNodeText(node, "update_time"), CultureInfo.InvariantCulture));
                }
                group.Office = XmlHelper.GetNodeText(node, "office");
                group.WebSite = XmlHelper.GetNodeText(node, "website");
                group.Venue = LocationParser.ParseLocation(((XmlElement)node).GetElementsByTagName("venue")[0]);
            }
            return group;
        }
        
    }
}
