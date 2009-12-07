using System;
using System.Drawing;
using System.Net;
using System.Xml.Serialization;
using Facebook.Properties;
using Facebook.Utility;

namespace Facebook
{
    [Serializable]
    public class FacebookEvent
    {
#region Private Data
        private string _eventId;
        private string _name;
        private string _tagLine;
        private string _networkId;
        private Image _picture;
        private byte[] _pictureBytes;
        private Uri _pictureUrl;
        private string _host;
        private string _description;
        private string _type;
        private string _subType;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _creator;
        private DateTime _updateDate;
        private string _location;
        private Location _venue;

#endregion Private Data

#region Properties
        /// <summary>
        /// The facebook unique identifier of the event
        /// </summary>
        public string EventId
        {
            get { return _eventId; }
            set { _eventId = value; }
        }
        /// <summary>
        /// The name of the event
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// The event's tagline
        /// </summary>
        public string TagLine
        {
            get { return _tagLine; }
            set { _tagLine = value; }
        }
        /// <summary>
        /// The facebook unique identifier of the network this event is affiliated with
        /// </summary>
        public string NetworkId
        {
            get { return _networkId; }
            set { _networkId = value; }
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
            get {
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
        /// The name of the event host
        /// </summary>
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }
        /// <summary>
        /// The description of the event
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// The type of the event
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// The sub-type of the event
        /// </summary>
        public string SubType
        {
            get { return _subType; }
            set { _subType = value; }
        }
        /// <summary>
        /// The starting date of the event
        /// </summary>
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        /// <summary>
        /// The ending date of the event
        /// </summary>
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        /// <summary>
        /// The creator of the event
        /// </summary>
        public string Creator
        {
            get { return _creator; }
            set { _creator = value; }
        }
        /// <summary>
        /// The last time the event was updated
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
        /// <summary>
        /// The location of the event
        /// </summary>
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        /// <summary>
        /// The venue of the event
        /// </summary>
        public Location Venue
        {
            get { return _venue; }
            set { _venue = value; }
        }

#endregion Properties

        /// <summary>
        /// The default constructor
        /// </summary>
        public FacebookEvent() { }
    }
}