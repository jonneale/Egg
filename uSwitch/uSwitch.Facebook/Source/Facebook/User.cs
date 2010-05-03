using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Xml.Serialization;
using Facebook.Properties;
using Facebook.Utility;

namespace Facebook
{
#region Enums

    public enum Gender
    {
        [Description("")]
        Unknown,
        Male,
        Female
    }
    public enum LookingFor
    {
        [DescriptionAttribute("")]
        Unknown,
        Friendship,
        [DescriptionAttribute("A Relationship")]
        ARelationship,
        Dating,
        [DescriptionAttribute("Random Play")]
        RandomPlay,
        [DescriptionAttribute("Whatever I Can Get")]
        WhateverIcanget
    }

    public enum RelationshipStatus
    {
        [DescriptionAttribute("")]
        Unknown,
        Single,
        [DescriptionAttribute("In A Relationship")]
        InARelationship,
        [DescriptionAttribute("In An Open Relationship")]
        InAnOpenRelationship,
        Engaged,
        Married,
        [DescriptionAttribute("It's Complicated")]
        ItsComplicated
    }

    public enum PoliticalView
    {
        [DescriptionAttribute("")]
        Unknown,
        [DescriptionAttribute("Very Liberal")]
        VeryLiberal,
        Liberal,
        Moderate,
        Conservative,
        [DescriptionAttribute("Very Conservative")]
        VeryConservative,
        Apathetic,
        Libertarian,
        Other
    }

#endregion


    [Serializable]
    public class User
    {
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
        private Image _picture;
        private byte[] _pictureBytes;
        private Uri _pictureUrl;
        private Collection<Network> _affiliations;
        private SchoolHistory _schoolHistory;
        private Collection<Work> _workHistory;
        private string _religion = string.Empty;
        private Gender _sex;
        private Location _hometownLocation;
        private Location _currentLocation;
        private Collection<Gender> _interestedInGenders;
        private Collection<LookingFor> _interstedInRelationshipTypes;
        private RelationshipStatus _relationshipStatus;
        private PoliticalView _politicalView;
        private string _significantOtherId = string.Empty;
        private int _notesCount;
        private int _wallCount;
        private Status _status = new Status();
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
        /// Collection of networks this person is affiliated with
        /// </summary>
        public Collection<Network> Affiliations
        {
            get 
            {
                if (_affiliations == null)
                    _affiliations = new Collection<Network>();

                return _affiliations; 
            }
        }

        /// <summary>
        /// user's gender
        /// </summary>
        public Gender Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        /// <summary>
        /// user's hometown
        /// </summary>
        public Location HometownLocation
        {
            get { return _hometownLocation; }
            set { _hometownLocation = value; }
        }

        /// <summary>
        /// user's current location
        /// </summary>
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }

        /// <summary>
        /// collection of genders this user is interested in
        /// </summary>
        public Collection<Gender> InterestedInGenders
        {
            get { return _interestedInGenders; }
            set { _interestedInGenders = value; }
        }

        /// <summary>
        /// collection of relationship types this user is interested in
        /// </summary>
        public Collection<LookingFor> InterstedInRelationshipTypes
        {
            get { return _interstedInRelationshipTypes; }
            set { _interstedInRelationshipTypes = value; }
        }

        /// <summary>
        /// user's relationship status
        /// </summary>
        public RelationshipStatus RelationshipStatus
        {
            get { return _relationshipStatus; }
            set { _relationshipStatus = value; }
        }

        /// <summary>
        /// user's political view
        /// </summary>
        public PoliticalView PoliticalView
        {
            get { return _politicalView; }
            set { _politicalView = value; }
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
        /// user's school history
        /// </summary>
        public SchoolHistory SchoolHistory
        {
            get { return _schoolHistory; }
            set { _schoolHistory = value; }
        }
        /// <summary>
        /// user's work history
        /// </summary>
        public Collection<Work> WorkHistory
        {
            get { return _workHistory; }
            set { _workHistory = value; }
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
        /// <summary>
        /// </summary>
        public Status Status
        {
            get { return _status; }
        }
        #endregion Properties


        /// <summary>
        /// Default constructor
        /// </summary>
        public User()
        {
        }
        
    }
}
