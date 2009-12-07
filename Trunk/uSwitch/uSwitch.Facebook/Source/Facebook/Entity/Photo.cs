using System;
using System.Drawing;
using System.Net;
using System.Xml.Serialization;
using Facebook.Properties;
using Facebook.Utility;

namespace Facebook.Entity {
    [Serializable]
    public class Photo
    {
        #region Private Data
        private string _photoId;
        private string _albumId;
        private string _ownerUserId;
        private Uri _link;
        private Image _picture;
        private byte[] _pictureBytes;
        private Uri _pictureUrl;
        private Image _pictureSmall;
        private byte[] _pictureSmallBytes;
        private Uri _pictureSmallUrl;
        private Image _pictureBig;
        private byte[] _pictureBigBytes;
        private Uri _pictureBigUrl;
        private string _caption;
        private DateTime _createDate;


        #endregion Private Data

        #region Properties
        /// <summary>
        /// The facebook unique identifier of the photo
        /// </summary>
        public string PhotoId
        {
            get { return _photoId; }
            set { _photoId = value; }
        }
        /// <summary>
        /// The facebook unique identifier of the album that this photo is part of
        /// </summary>
        public string AlbumId
        {
            get { return _albumId; }
            set { _albumId = value; }
        }
        /// <summary>
        /// The facebook unique identifier of the user who owns the picture and album
        /// </summary>
        public string OwnerUserId
        {
            get { return _ownerUserId; }
            set { _ownerUserId = value; }
        }
        /// <summary>
        /// The facebook unique identifier of the user who owns the picture and album
        /// </summary>
        public Uri Link
        {
            get { return _link; }
            set { _link = value; }
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
        /// The picture of the event (small version).  This is not initially populated, but when accessed will stream the bytes of the picture
        /// from the url and provide an actual picture
        /// </summary>
        [XmlIgnore()]
        public Image PictureSmall
        {
            get
            {
                if (_pictureSmallUrl == null)
                {
                    return Resources.missingPicture;
                }
                else if (_pictureSmall == null)
                {
                    WebClient webClient = new WebClient();
                    _pictureSmallBytes = webClient.DownloadData(_pictureSmallUrl);
                    _pictureSmall = ImageHelper.ConvertBytesToImage(_pictureSmallBytes);
                    return _pictureSmall;
                }
                else
                {
                    return _pictureSmall;
                }
            }
            set { _pictureSmall = value; }
        }
        /// <summary>
        /// This is only used for serialization.  Should not be accessed directly.  (small version)
        /// </summary>
        [XmlElementAttribute("PictureSmall")]
        public byte[] PictureSmallBytes
        {
            get
            {
                if (_pictureSmallUrl == null)
                {
                    return null;
                }
                else if (_pictureSmallBytes == null)
                {
                    WebClient webClient = new WebClient();
                    _pictureSmallBytes = webClient.DownloadData(_pictureSmallUrl);
                    _pictureSmall = ImageHelper.ConvertBytesToImage(_pictureSmallBytes);
                    return _pictureSmallBytes;
                }
                else
                {
                    return _pictureSmallBytes;
                }
            }
        }
        /// <summary>
        /// The url of the event picture (small version)
        /// </summary>
        public Uri PictureSmallUrl
        {
            get
            {
                if (_pictureSmallUrl == null)
                {
                    return new Uri(Resources.MissingPictureUrl);
                }
                else
                {
                    return _pictureSmallUrl;
                }
            }
            set { _pictureSmallUrl = value; }
        }
        /// <summary>
        /// The picture of the event (Big version).  This is not initially populated, but when accessed will stream the bytes of the picture
        /// from the url and provide an actual picture
        /// </summary>
        [XmlIgnore()]
        public Image PictureBig
        {
            get
            {
                if (_pictureBigUrl == null)
                {
                    return Resources.missingPicture;
                }
                else if (_pictureBig == null)
                {
                    WebClient webClient = new WebClient();
                    _pictureBigBytes = webClient.DownloadData(_pictureBigUrl);
                    _pictureBig = ImageHelper.ConvertBytesToImage(_pictureBigBytes);
                    return _pictureBig;
                }
                else
                {
                    return _pictureBig;
                }
            }
            set { _pictureBig = value; }
        }
        /// <summary>
        /// This is only used for serialization.  Should not be accessed directly.  (Big version)
        /// </summary>
        [XmlElementAttribute("PictureBig")]
        public byte[] PictureBigBytes
        {
            get
            {
                if (_pictureBigUrl == null)
                {
                    return null;
                }
                else if (_pictureBigBytes == null)
                {
                    WebClient webClient = new WebClient();
                    _pictureBigBytes = webClient.DownloadData(_pictureBigUrl);
                    _pictureBig = ImageHelper.ConvertBytesToImage(_pictureBigBytes);
                    return _pictureBigBytes;
                }
                else
                {
                    return _pictureBigBytes;
                }
            }
        }
        /// <summary>
        /// The url of the event picture (Big version)
        /// </summary>
        public Uri PictureBigUrl
        {
            get
            {
                if (_pictureBigUrl == null)
                {
                    return new Uri(Resources.MissingPictureUrl);
                }
                else
                {
                    return _pictureBigUrl;
                }
            }
            set { _pictureBigUrl = value; }
        }

        /// <summary>
        /// The caption associated with the picture
        /// </summary>
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        /// <summary>
        /// The date picture was created
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }


        #endregion Properties

        /// <summary>
        /// Default constructor
        /// </summary>
        public Photo()
        {
        }
    }
}