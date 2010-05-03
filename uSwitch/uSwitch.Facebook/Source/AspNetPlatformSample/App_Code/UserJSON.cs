using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Serialization;
using System.Net;
using System.IO;
using Facebook.Entity;
/// <summary>
/// Summary description for User
/// </summary>
[Serializable]
public class UserJSON
{
    public UserJSON()
    {
    }
    public UserJSON(Facebook.Entity.User u)
    {
        this.AboutMe = u.AboutMe;
        this.Activities = u.Activities;
        this.Birthday = u.Birthday;
        this.Books = u.Books;
        this.FirstName = u.FirstName;
        this.Interests = u.Interests;
        this.LastName = u.LastName;
        this.Movies = u.Movies;
        this.Music = u.Music;
        this.Name = u.Name;
        this.NotesCount = u.NotesCount;
        this.Picture = u.Picture;
        this.PictureUrl = u.PictureUrl;
        this.ProfileUpdateDate = u.ProfileUpdateDate;
        this.Quotes = u.Quotes;
        this.Religion = u.Religion;
        this.SignificantOtherId = u.SignificantOtherId;
        this.TVShows = u.TVShows;
        this.UserId = u.UserId;
        this.WallCount = u.WallCount;
    }

    public static UserJSON[] ConvertFacebookUserArray(Collection<Facebook.Entity.User> users)
    {
        UserJSON[] a = new UserJSON[users.Count];
        for (int i = 0; i < users.Count; i++)
        {
            a[i] = new UserJSON(users[i]);
        }
        return a;
    }
        #region Private Data

        private string _userId = string.Empty;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _name = string.Empty;
        private DateTime? _birthday;
        private string _music = string.Empty;
        private string _activities = string.Empty;
        private string _interests = string.Empty;
        private string _tvShows = string.Empty;
        private string _movies = string.Empty;
        private string _books = string.Empty;
        private string _quotes = string.Empty;
        private string _aboutMe = string.Empty;
        private System.Drawing.Image _picture;
        private byte[] _pictureBytes;
        private Uri _pictureUrl;
        private string _pictureUrlString;
        private string _religion = string.Empty;
        private string _significantOtherId = string.Empty;
        private int _notesCount;
        private int _wallCount;
        private DateTime _profileUpdateDate;

        #endregion Private Data

        #region Properties

        /// <summary>
        /// Facebook unique identifier of the user
        /// </summary>
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        /// <summary>
        /// User's first name
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        /// <summary>
        /// User's last name
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        /// <summary>
        /// User's name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// User's birthday
        /// </summary>
        public DateTime? Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        /// <summary>
        /// User's birthday
        /// </summary>
        public DateTime ProfileUpdateDate
        {
            get { return _profileUpdateDate; }
            set { _profileUpdateDate = value; }
        }

        /// <summary>
        /// Free form text of music this user likes
        /// </summary>
        public string Music
        {
            get { return _music; }
            set { _music = value; }
        }

        /// <summary>
        /// Free form text of activities this user does
        /// </summary>
        public string Activities
        {
            get { return _activities; }
            set { _activities = value; }
        }

        /// <summary>
        /// Free form text of this user's interests
        /// </summary>
        public string Interests
        {
            get { return _interests; }
            set { _interests = value; }
        }

        /// <summary>
        /// Free form text of this user's favorite tv shows
        /// </summary>
        public string TVShows
        {
            get { return _tvShows; }
            set { _tvShows = value; }
        }

        /// <summary>
        /// Free form text of this user's favorite movies
        /// </summary>
        public string Movies
        {
            get { return _movies; }
            set { _movies = value; }
        }

        /// <summary>
        /// Free form text of this user's favorite books
        /// </summary>
        public string Books
        {
            get { return _books; }
            set { _books = value; }
        }

        /// <summary>
        /// Free form text of this user's favorite quotes
        /// </summary>
        public string Quotes
        {
            get { return _quotes; }
            set { _quotes = value; }
        }

        /// <summary>
        /// Free form text describing this user
        /// </summary>
        public string AboutMe
        {
            get { return _aboutMe; }
            set { _aboutMe = value; }
        }
        /// <summary>
        /// The picture of the event.  This is not initially populated, but when accessed will stream the bytes of the picture
        /// from the url and provide an actual picture
        /// </summary>
        [XmlIgnore()]
        public System.Drawing.Image Picture
        {
            get
            {
                if (_picture == null)
                {
                    WebClient webClient = new WebClient();
                    _pictureBytes = webClient.DownloadData(_pictureUrl);
                    _picture = ConvertBytesToImage(_pictureBytes);
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
        //[XmlElementAttribute("Picture")]
        //public byte[] PictureBytes
        //{
        //    get
        //    {
        //        if (_pictureUrl == null)
        //        {
        //            return null;
        //        }
        //        else if (_pictureBytes == null)
        //        {
        //            WebClient webClient = new WebClient();
        //            _pictureBytes = webClient.DownloadData(_pictureUrl);
        //            _picture = ImageHelper.ConvertBytesToImage(_pictureBytes);
        //            return _pictureBytes;
        //        }
        //        else
        //        {
        //            return _pictureBytes;
        //        }
        //    }
        //}
        /// <summary>
        /// The url of the event picture
        /// </summary>
        [XmlIgnore()]
        public Uri PictureUrl
        {
            get
            {
                if (_pictureUrl == null)
                {
                    return new Uri("http://static.ak.facebook.com/pics/s_default.jpg");
                }
                else
                {
                    return _pictureUrl;
                }
            }
            set { _pictureUrl = value; }
        }
        [XmlElementAttribute("PictureUrl")]
        public string PictureUrlString
        {
            get {
                if (_pictureUrl != null)
                    return _pictureUrl.ToString();
                else
                    return string.Empty;
            }
            set { _pictureUrlString = value; }
        }


        /// <summary>
        /// facebook unique identifier of the significant other of this user
        /// </summary>
        public string SignificantOtherId
        {
            get { return _significantOtherId; }
            set { _significantOtherId = value; }
        }
        /// <summary>
        /// user's religion
        /// </summary>
        public string Religion
        {
            get { return _religion; }
            set { _religion = value; }
        }
        /// <summary>
        /// count of notes
        /// </summary>
        public int NotesCount
        {
            get { return _notesCount; }
            set { _notesCount = value; }
        }
        /// <summary>
        /// Number of messages on the wall
        /// </summary>
        public int WallCount
        {
            get { return _wallCount; }
            set { _wallCount = value; }
        }
        #endregion
        internal static System.Drawing.Image ConvertBytesToImage(byte[] imageBytes)
        {
            System.Drawing.Image image;
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                image = System.Drawing.Image.FromStream(ms, true);
            }
            return image;
        }
    }
