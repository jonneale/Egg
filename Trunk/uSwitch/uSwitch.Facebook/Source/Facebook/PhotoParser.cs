using System;
using System.Globalization;
using System.Xml;
using Facebook.Utility;

namespace Facebook
{
    internal sealed class PhotoParser
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        private PhotoParser() { }

        /// <summary>
        /// Uses DOM parsing to constitute a Photo data object given the xml returned from facebook
        /// </summary>
        internal static Photo ParsePhoto(XmlNode node)
        {
            Photo photo = new Photo();
            if (node != null)
            {
                photo.PhotoId = XmlHelper.GetNodeText(node, "pid");
                photo.AlbumId = XmlHelper.GetNodeText(node, "aid");
                photo.AlbumId = XmlHelper.GetNodeText(node, "aid");
                photo.OwnerUserId = XmlHelper.GetNodeText(node, "owner");
                if (!String.IsNullOrEmpty(XmlHelper.GetNodeText(node, "src")))
                {
                    photo.PictureUrl = new Uri(XmlHelper.GetNodeText(node, "src"));
                }
                if (!String.IsNullOrEmpty(XmlHelper.GetNodeText(node, "link")))
                {
                    photo.Link = new Uri(XmlHelper.GetNodeText(node, "link"));
                }
                photo.Caption = XmlHelper.GetNodeText(node, "caption");
                if (!String.IsNullOrEmpty(XmlHelper.GetNodeText(node, "created")))
                {
                    photo.CreateDate = DateHelper.ConvertDoubleToDate(double.Parse(XmlHelper.GetNodeText(node, "created"), CultureInfo.InvariantCulture));
                }
            }
            return photo;
        }
    }
}
