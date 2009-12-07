using System;
using System.Drawing;
using System.Net;
using System.Xml.Serialization;
using Facebook.Properties;
using Facebook.Utility;

namespace Facebook
{
    public enum GroupType
    {
        Unknown,
        College,
        HighSchool,
        Work,
        Region
    }
    [Serializable]
    public class Group
    {
#region Private Data

        private string _groupId;
        private string _networkId;
        private string _name;
        private string _type;
        private string _subType;
        private string _recentNews;
        private string _creator;
        private DateTime _updateDate;
        private string _office;
        private string _webSite;
        private Location _venue;
        private Image _picture;
        private byte[] _pictureBytes;
        private Uri _pictureUrl;
        private string _description;


#endregion Private Data

#region Properties
        /// <summary>
        /// The facebook unique identifier of the group
        /// </summary>
        public string GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }
        /// <summary>
        /// The facebook unique identifier of the network that the group is affiliated with
        /// </summary>
        public string NetworkId
        {
            get { return _networkId; }
            set { _networkId = value; }
        }
        /// <summary>
        /// The name of the group
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// The type of group
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// The sub-type of group
        /// </summary>
        public string SubType
        {
            get { return _subType; }
            set { _subType = value; }
        }
        /// <summary>
        /// Any news about the group
        /// </summary>
        public string RecentNews
        {
            get { return _recentNews; }
            set { _recentNews = value; }
        }
        /// <summary>
        /// The name of the group creator
        /// </summary>
        public string Creator
        {
            get { return _creator; }
            set { _creator = value; }
        }
        /// <summary>
        /// The last time the group was updated
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
        /// <summary>
        /// The description of the group office
        /// </summary>
        public string Office
        {
            get { return _office; }
            set { _office = value; }
        }
        /// <summary>
        /// Link to group's website 
        /// </summary>
        public string WebSite
        {
            get { return _webSite; }
            set { _webSite = value; }
        }
        /// <summary>
        /// Location of group's headquarters
        /// </summary>
        public Location Venue
        {
            get { return _venue; }
            set { _venue = value; }
        }
        /// <summary>
        /// The picture of the event.  This is not initially populated, but when accessed will stream the bytes of the picture
        /// from the url and provide an actual picture
        /// </summary>
        [XmlIgnore()]
        public Image Picture
        {
            get
            {
                if (_pictureUrl == null)
                {
                    return Resources.missingPicture;
                }
                else if (_picture == null)
                {
                    WebClient webClient = new WebClient();
                    _pictureBytes = webClient.DownloadData(_pictureUrl);
                    _picture = ImageHelper.ConvertBytesToImage(_pictureBytes);
                    return _picture;
                }
                else
                {
                    return _picture;
                }
            }
            set { _picture = value; }
        }
        /// <summary>
        /// This is only used for serialization.  Should not be accessed directly.
        /// </summary>
        [XmlElementAttribute("Picture")]
        public byte[] PictureBytes
        {
            get
            {
                if (_pictureUrl == null)
                {
                    return null;
                }
                else if (_pictureBytes == null)
                {
                    WebClient webClient = new WebClient();
                    _pictureBytes = webClient.DownloadData(_pictureUrl);
                    _picture = ImageHelper.ConvertBytesToImage(_pictureBytes);
                    return _pictureBytes;
                }
                else
                {
                    return _pictureBytes;
                }
            }
        }
        /// <summary>
        /// The url of the event picture
        /// </summary>
        public Uri PictureUrl
        {
            get
            {
                if (_pictureUrl == null)
                {
                    return new Uri(Resources.MissingPictureUrl);
                }
                else
                {
                    return _pictureUrl;
                }
            }
            set { _pictureUrl = value; }
        }
        /// <summary>
        /// The description of the group
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

#endregion Properties

        /// <summary>
        /// default constructor
        /// </summary>
        public Group()
        {
        }
    }
}