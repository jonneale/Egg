using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Facebook.API;
using Facebook.Entity;
using Facebook.Exceptions;
using Facebook.Forms;
using Facebook.Properties;

namespace Facebook.Components {
    [ToolboxItem(true), ToolboxBitmap(typeof (FacebookService))]
    [Designer(typeof (FacebookServiceDesigner))]
    public partial class FacebookService : Component, Facebook.Components.IFacebookService {
        #region Private Data

        private readonly FacebookAPI _facebookAPI;

        #endregion Private Data

        #region Accessors

        /// <summary>
        /// Access Key required to use the Api
        /// </summary>
        [Category("Facebook")]
        [Description("Access Key required to use the Api")]
        public string ApplicationKey {
            get { return _facebookAPI.ApplicationKey; }
            set { _facebookAPI.ApplicationKey = value; }
        }

        /// <summary>
        /// User Id
        /// </summary>
        [Browsable(false)]
        public string UserId {
            get { return _facebookAPI.UserId; }
            set { _facebookAPI.UserId = value; }
        }

        /// <summary>
        /// Secret word
        /// </summary>
        [Category("Facebook")]
        [Description("Secret Word")]
        public string Secret {
            get { return _facebookAPI.Secret; }
            set { _facebookAPI.Secret = value; }
        }

        /// <summary>
        /// Session key
        /// </summary>
        [Browsable(false)]
        public string SessionKey {
            get { return _facebookAPI.SessionKey; }
            set { _facebookAPI.SessionKey = value; }
        }

        /// <summary>
        /// Session key
        /// </summary>
        [Browsable(false)]
        public bool SessionExpires {
            get { return _facebookAPI.SessionExpires; }
        }

        /// <summary>
        /// Login Url
        /// </summary>
        [Browsable(false)]
        private string LoginUrl {
            get {
                object[] args = new object[2];
                args[0] = _facebookAPI.ApplicationKey;
                args[1] = _facebookAPI.AuthToken;

                return String.Format(CultureInfo.InvariantCulture, Resources.FacebookLoginUrl, args);
            }
        }

        /// <summary>
        /// LogOff Url
        /// </summary>
        [Browsable(false)]
        private string LogOffUrl {
            get {
                object[] args = new object[2];
                args[0] = _facebookAPI.ApplicationKey;
                args[1] = _facebookAPI.AuthToken;

                return String.Format(CultureInfo.InvariantCulture, Resources.FacebookLogoutUrl, args);
            }
        }

        /// <summary>
        /// isDesktopApplication
        /// </summary>
        [Browsable(false)]
        public bool IsDesktopApplication {
            get { return _facebookAPI.IsDesktopApplication; }
            set { _facebookAPI.IsDesktopApplication = value; }
        }

        #endregion

        #region Constructors

        public FacebookService() {
            _facebookAPI = new FacebookAPI();
            InitializeComponent();
        }

        public FacebookService(IContainer container) {
            if (container != null)
                container.Add(this);

            _facebookAPI = new FacebookAPI();
            InitializeComponent();
        }

        #endregion Constuctors

        #region Public Methods

        /// <summary>
        /// Used to display integrated browser for logon on facebook web page.
        /// </summary>
        public void ConnectToFacebook() {
            DialogResult result;
            SetAuthenticationToken();

            using (FacebookAuthentication formLogin = new FacebookAuthentication(LoginUrl)) {
                result = formLogin.ShowDialog();
            }
            if (result == DialogResult.OK) {
                _facebookAPI.CreateSession();
            }
            else {
                throw new FacebookInvalidUserException("Login attempt failed");
            }
        }

        /// <summary>
        /// Used to logout.
        /// </summary>
        public void LogOff() {
            FacebookAPI.GetQueryResponse(LogOffUrl, "");
        }

        /// <summary>
        /// Method creates and returns the authentication token
        /// </summary>
        private void SetAuthenticationToken() {
            Dictionary<string, string> parameterList = new Dictionary<string, string>(2);
            parameterList.Add("method", "facebook.auth.createToken");

            XmlDocument xmlDocument = _facebookAPI.ExecuteApiCall(parameterList, false);

            // Get the authToken
            _facebookAPI.AuthToken =
                xmlDocument.SelectSingleNode("Facebook:auth_createToken_response", _facebookAPI.NsManager).InnerText;
        }

        /// <summary>
        /// Method creates a session
        /// </summary>
        public void CreateSession(string authToken) {
            _facebookAPI.AuthToken = authToken;
            _facebookAPI.CreateSession(authToken);
        }

        /// <summary>
        /// Sends a direct FQL query to FB
        /// </summary>
        /// <param name="query">FQL Query</param>
        /// <returns>XML string as a result of FQL query</returns> 
        public string DirectFQLQuery(string query) {
            string results = string.Empty;
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }

            try {
                results = _facebookAPI.DirectFQLQuery(query);
            }
            catch (FacebookTimeoutException) {
                // Reconnect because of timed out session
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    DirectFQLQuery(query);
                }
                else
                {
                    throw;
                }
            }

            return results;
        }


        /// <summary>
        /// Get all events for the logged in user.
        /// </summary>
        /// <returns>event list</returns>
        public Collection<FacebookEvent> GetEvents() {
            return GetEvents(null, _facebookAPI.UserId, null, null);
        }

        /// <summary>
        /// Get all events for the specified user.
        /// </summary>
        /// <param name="userId">User to return events for</param>
        /// <returns>event list</returns>
        public Collection<FacebookEvent> GetEvents(string userId) {
            return GetEvents(null, userId, null, null);
        }

        /// <summary>
        /// Get all events in the list of events.
        /// </summary>
        /// <param name="eventList">list of event ids</param>
        /// <returns>event list</returns>
        public Collection<FacebookEvent> GetEvents(Collection<string> eventList) {
            return GetEvents(eventList, null, null, null);
        }

        /// <summary>
        /// Get all events for the specified user and list of events
        /// </summary>
        /// <param name="userId">User to return events for</param>
        /// <param name="eventList">list of event ids</param>
        /// <returns>event list</returns>
        public Collection<FacebookEvent> GetEvents(Collection<string> eventList, string userId) {
            return GetEvents(eventList, userId, null, null);
        }

        /// <summary>
        /// Get all events for the specified user and list of events between 2 dates
        /// </summary>
        /// <param name="userId">User to return events for</param>
        /// <param name="eventList">list of event ids</param>
        /// <param name="startDate">events occuring after this date</param>
        /// <param name="endDate">events occuring before this date</param>
        /// <returns>event list</returns>
        public Collection<FacebookEvent> GetEvents(Collection<string> eventList, string userId, DateTime? startDate,
                                                   DateTime? endDate) {
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            return _facebookAPI.GetEvents(eventList, userId, startDate, endDate);
        }

        /// <summary>
        /// Get the XML representation of all events for the specified user and list of events between 2 dates
        /// </summary>
        /// <param name="userId">User to return events for</param>
        /// <param name="eventList">list of event ids</param>
        /// <param name="startDate">events occuring after this date</param>
        /// <param name="endDate">events occuring before this date</param>
        /// <returns>event list as raw XML</returns> 
        public string GetEventsXML(Collection<string> eventList, string userId, DateTime? startDate, DateTime? endDate) {
            string results = string.Empty;
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            try {
                results = _facebookAPI.GetEventsXML(eventList, userId, startDate, endDate);
            }
            catch (FacebookTimeoutException) {
                // Reconnect because of timed out session
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    GetEventsXML(eventList, userId, startDate, endDate);
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// Get all event members for the specified event
        /// </summary>
        /// <param name="eventId">Event to return users for</param>
        /// <returns>evet user list with rsvp status</returns>
        public Collection<EventUser> GetEventMembers(string eventId) {
            return _facebookAPI.GetEventMembers(eventId);
        }

        /// <summary>
        /// Get all event members for the specified event
        /// </summary>
        /// <param name="eventId">Event to return users for</param>
        /// <returns>evet user list with rsvp status</returns>
        public string GetEventMembersXML(string eventId) {
            string results = string.Empty;
            if (!IsSessionActive() && IsDesktopApplication)
            {
                ConnectToFacebook();
            }
            try {
                results = _facebookAPI.GetEventMembersXML(eventId);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    GetEventMembersXML(eventId);
                }
                else
                {
                    throw;
                }
            }
            return results;
        }

        /// <summary>
        /// Get all the friends for the logged in user
        /// </summary>
        /// <returns>user profile of each friend</returns>
        public Collection<User> GetFriends() {
            if (!IsSessionActive() && IsDesktopApplication)
            {
                ConnectToFacebook();
            }
            return _facebookAPI.GetFriends();
        }

        /// <summary>
        /// Get all the friends for the logged in user
        /// </summary>
        /// <returns>user profile of each friend</returns>
        public Collection<string> GetFriendIds()
        {
            if (!IsSessionActive() && IsDesktopApplication)
            {
                ConnectToFacebook();
            }
            return _facebookAPI.GetFriendIds();
        }

        /// <summary>
        /// Get all the friends for the logged in user and returns the results as raw XML
        /// </summary>
        /// <returns>The XMl representation of the user profile of each friend</returns>
        public string GetFriendsXML() {
            string results = string.Empty;
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }

            try {
                results = _facebookAPI.GetFriendsXML();
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    GetFriendsXML();
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// Get all the friends for the logged in user that use the current application 
        /// </summary>
        /// <returns>user profile of each friend</returns>
        public Collection<User> GetFriendsNonAppUsers()
        {
            if (!IsSessionActive() && IsDesktopApplication)
            {
                ConnectToFacebook();
            }
            return _facebookAPI.GetFriendsNonAppUsers();
        }
        /// <summary>
        /// Get all the friends for the logged in user that use the current application 
        /// </summary>
        /// <returns>user profile of each friend</returns>
        public Collection<User> GetFriendsAppUsers() {
            if (!IsSessionActive() && IsDesktopApplication)
            {
                ConnectToFacebook();
            }
            return _facebookAPI.GetFriendsAppUsers();
        }

        /// <summary>
        /// Get all the friends for the logged in user that use the current application 
        /// </summary>
        /// <returns>user profile of each friend</returns>
        public string GetFriendsAppUsersXML() {
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            string results = string.Empty;

            try {
                results = _facebookAPI.GetFriendsAppUsersXML();
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    GetFriendsAppUsersXML();
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// Determine if the two specified users are friends
        /// </summary>
        /// <param name="user1">User to check</param>
        /// <param name="user2">User to check</param>
        /// <returns>whether specified users are friends or not</returns>
        public bool AreFriends(User user1, User user2) {
            if (user1 == null) {
                throw new ArgumentNullException("user1");
            }

            if (user2 == null) {
                throw new ArgumentNullException("user2");
            }

            return AreFriends(user1.UserId, user2.UserId);
        }

        /// <summary>
        /// Determine if the two specified users are friends
        /// </summary>
        /// <param name="userId1">User to check</param>
        /// <param name="userId2">User to check</param>
        /// <returns>whether specified users are friends or not</returns>
        public bool AreFriends(string userId1, string userId2) {
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }

            try {
                return _facebookAPI.AreFriends(userId1, userId2);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    AreFriends(userId1, userId2);
                }
                else
                {
                    throw;
                }
            }

            return false;
        }

        /// <summary>
        /// Build the user profile for the logged in user
        /// </summary>
        /// <returns>user profile</returns>
        public User GetUserInfo() {
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            return _facebookAPI.GetUserInfo();
        }

        /// <summary>
        /// Build the user profile for the list of users
        /// </summary>
        /// <param name="userIds">Comma separated list of user ids</param>
        /// <returns>user profile list</returns>
        public Collection<User> GetUserInfo(string userIds) {
            if (!IsSessionActive() && IsDesktopApplication)
            {
                ConnectToFacebook();
            }
            return _facebookAPI.GetUserInfo(userIds);
        }


        /// <summary>
        /// Build the user profile for the list of users
        /// </summary>
        /// <param name="userIds">A collection of userId strings</param>
        /// <returns>user profile list</returns>
        public Collection<User> GetUserInfo(Collection<string> userIds) {
            if (!IsSessionActive() && IsDesktopApplication)
            {
                ConnectToFacebook();
            }
            return _facebookAPI.GetUserInfo(userIds);
        }


        /// <summary>
        /// Builds the user profile for the list of users and returns the results as raw xml
        /// </summary>
        /// <param name="userIds">Comma separated list of user ids</param>
        /// <returns>The xml representation of the user profile list</returns>
        public string GetUserInfoXml(string userIds) {
            string results = string.Empty;

            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }

            try {
                results = _facebookAPI.GetUserInfoXml(userIds);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    GetUserInfoXml(userIds);
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// Return the notifications
        /// </summary>
        /// <returns>user profile list</returns>
        public Notifications GetNotifications() {
            if (!IsSessionActive() && IsDesktopApplication)
            {
                ConnectToFacebook();
            }
            return _facebookAPI.GetNotifications();
        }

        /// <summary>
        /// Builds the list of notifications and returns the results as raw xml
        /// </summary>
        /// <returns>The xml representation of the user profile list</returns>
        public string GetNotificationsXml() {
            string results = string.Empty;

            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            try {
                results = _facebookAPI.GetNotificationsXml();
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    GetNotificationsXml();
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// Get the photos for a specified album
        /// </summary>
        /// <param name="albumId">The album</param>
        /// <returns>photos</returns>
        public Collection<Photo> GetPhotos(string albumId) {
            return GetPhotos(albumId, null, null);
        }

        /// <summary>
        /// Get the photos for a specified list of photos
        /// </summary>
        /// <param name="photoList">Collection of photo ids</param>
        /// <returns>photos</returns>
        public Collection<Photo> GetPhotos(Collection<string> photoList) {
            return GetPhotos(null, photoList, null);
        }

        /// <summary>
        /// Get the photos for a specified User
        /// </summary>
        /// <param name="user">The user</param>
        /// <returns>photos</returns>
        public Collection<Photo> GetPhotos(User user) {
            return GetPhotos(null, null, user);
        }

        /// <summary>
        /// Get the photos for a specified album and list of photos
        /// </summary>
        /// <param name="albumId">The album</param>
        /// <param name="photoList">Collection of photo ids</param>
        /// <returns>photos</returns>
        public Collection<Photo> GetPhotos(string albumId, Collection<string> photoList) {
            return GetPhotos(albumId, photoList, null);
        }

        /// <summary>
        /// Get the photos for a specified album, photo list, and User
        /// </summary>
        /// <param name="albumId">The album</param>
        /// <param name="photoList">Collection of photo ids</param>
        /// <param name="user">The user</param>
        /// <returns>photos</returns>
        public Collection<Photo> GetPhotos(string albumId, Collection<string> photoList, User user) {
            if (!IsSessionActive() && IsDesktopApplication)
            {
                ConnectToFacebook();
            }
            return _facebookAPI.GetPhotos(albumId, photoList, user);
        }

        /// <summary>
        /// Get the photos for a specified album and list of photos
        /// </summary>
        /// <param name="albumId">The album</param>
        /// <param name="photoList">Collection of photo ids</param>
        /// <returns>photos</returns>
        [Obsolete("We now include a more extensive version which includes a User as well")]
        public string GetPhotosXML(string albumId, Collection<string> photoList) {
            // Eventually, this version should be depreciated.
            // Simply call the newer function.
            return GetPhotosXML(albumId, photoList, null);
        }

        /// <summary>
        /// Get the photos for a specified album, list of photos, and User
        /// </summary>
        /// <param name="albumId">The album</param>
        /// <param name="photoList">Collection of photo ids</param>
        /// <param name="user">The user</param>
        /// <returns>photos</returns>
        public string GetPhotosXML(string albumId, Collection<string> photoList, User user) {
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            string results = string.Empty;
            try {
                results = _facebookAPI.GetPhotosXML(albumId, photoList, user);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    GetPhotosXML(albumId, photoList, user);
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// Get the albums for the logged in user
        /// </summary>
        /// <returns>albums</returns>
        public Collection<Album> GetPhotoAlbums() {
            return GetPhotoAlbums(_facebookAPI.UserId, null);
        }

        /// <summary>
        /// Get the albums for the specified user
        /// </summary>
        /// <param name="userId">user to return albums for</param>
        /// <returns>albums</returns>
        public Collection<Album> GetPhotoAlbums(string userId) {
            return GetPhotoAlbums(userId, null);
        }

        /// <summary>
        /// Get the albums for the specified list of albums
        /// </summary>
        /// <param name="albumList">collection of album ids</param>
        /// <returns>albums</returns>
        public Collection<Album> GetPhotoAlbums(Collection<string> albumList) {
            return GetPhotoAlbums(null, albumList);
        }

        /// <summary>
        /// Get the albums for the specified user and list of albums
        /// </summary>
        /// <param name="userId">user to return albums for</param>
        /// <param name="albumList">collection of album ids</param>
        /// <returns>albums</returns>
        public Collection<Album> GetPhotoAlbums(string userId, Collection<string> albumList) {
            if (!IsSessionActive() && IsDesktopApplication)
            {
                ConnectToFacebook();
            }
            return _facebookAPI.GetPhotoAlbums(userId, albumList);
        }

        /// <summary>
        /// Get the albums for the specified user and list of albums
        /// </summary>
        /// <param name="userId">user to return albums for</param>
        /// <param name="albumList">collection of album ids</param>
        /// <returns>albums</returns>
        public string GetPhotoAlbumsXML(string userId, Collection<string> albumList) {
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            string results = string.Empty;
            try {
                results = _facebookAPI.GetPhotoAlbumsXML(userId, albumList);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    GetPhotoAlbumsXML(userId, albumList);
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// Get the tags for the specifed photos
        /// </summary>
        /// <param name="photoList">collection of photo ids</param>
        /// <returns>photo tags</returns>
        public Collection<PhotoTag> GetTags(Collection<string> photoList) {
            if (!IsSessionActive() && IsDesktopApplication)
            {
                ConnectToFacebook();
            }
            return _facebookAPI.GetTags(photoList);
        }

        /// <summary>
        /// Get the tags for the specifed photos
        /// </summary>
        /// <param name="photoList">collection of photo ids</param>
        /// <returns>photo tags</returns>
        public string GetTagsXML(Collection<string> photoList) {
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            string results = string.Empty;
            try {
                results = _facebookAPI.GetTagsXML(photoList);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    GetTagsXML(photoList);
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// Set the FBML on a profile
        /// </summary>
        /// <param name="markup">html markup</param>
        public string SetFBML(string markup)
        {
            return SetFBML(markup, null);
        }
        /// <summary>
        /// Set the FBML on a profile
        /// </summary>
        /// <param name="markup">html markup</param>
        public string SetFBML(string markup, string userId) {
            string results = string.Empty;
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            try {
                results = _facebookAPI.SetFBML(markup, userId);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    SetFBML(markup, userId);
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// Send a notification
        /// </summary>
        /// <param name="markup">fbml markup</param>
        /// <param name="toList">list of users to be notified</param>
        public string SendNotification(string markup, string toList)
        {
            return SendNotification(markup, toList, null);
        }

            /// <summary>
        /// Send a notification
        /// </summary>
        /// <param name="markup">fbml markup</param>
        /// <param name="toList">list of users to be notified</param>
        /// <param name="email">fbml of email</param>
        public string SendNotification(string markup, string toList, string email) {
            string results = string.Empty;
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            try {
                results = _facebookAPI.SendNotification(markup, toList, email);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    SendNotification(markup, toList, email);
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// Send Request
        /// </summary>
        /// <param name="markup">fbml markup</param>
        /// <param name="toList">the list of users to gets request</param>
        /// <param name="requestType">type of request</param>
        /// <param name="imageUrl"> url of image</param>
        /// <param name="isInvite"></param>
        public string SendRequest(string markup, string toList, string requestType, Uri imageUrl, bool isInvite) {
            string results = string.Empty;
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            try {
                results = _facebookAPI.SendRequest(markup, toList, requestType, imageUrl, isInvite);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    SendRequest(markup, toList, requestType, imageUrl, isInvite);
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// publish story. it the default  priority is 1
        /// </summary>
        /// <param name="title">title of the story</param>
        /// <param name="body">body of the story</param>
        /// <param name="images">list of images</param>
        public string PublishStory(string title, string body, Collection<PublishImage> images)
        {
            return PublishStory(title, body, images, 1);
        }

        /// <summary>
        /// publish story. it the default  priority is 1
        /// </summary>
        /// <param name="title">title of the story</param>
        /// <param name="body">body of the story</param>
        /// <param name="images">list of images</param>
        /// <param name="priority">priority of story </param>
        public string PublishStory(string title, string body, Collection<PublishImage> images, int priority)
        {
            string results = string.Empty;
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            try {
                results = _facebookAPI.PublishStory(title, body, images, priority);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    PublishStory(title, body, images, priority);
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// publish action. it the default  priority is 1
        /// </summary>
        /// <param name="title">title of the action</param>
        /// <param name="body">body of the action</param>
        /// <param name="images">list of images</param>
        public string PublishAction(string title, string body, Collection<PublishImage> images)
        {
            return PublishAction(title, body, images, 1);
        }

        /// <summary>
        /// publish action. it the default  priority is 1
        /// </summary>
        /// <param name="title">title of the action</param>
        /// <param name="body">body of the action</param>
        /// <param name="images">list of images</param>
        /// <param name="priority">priority of action </param>
        public string PublishAction(string title, string body, Collection<PublishImage> images, int priority)
        {
            string results = string.Empty;
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            try {
                results = _facebookAPI.PublishAction(title, body, images);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    PublishAction(title, body, images, priority);
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// Upload the specified photo to the specified album.  The uploadFile should be a .jpg file
        /// </summary>
        /// <param name="albumId">album to upload to.  If not specified, will use default album</param>
        /// <param name="uploadFile">the .jpg file to upload</param>
        public void UploadPhoto(string albumId, FileInfo uploadFile) {
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            try {
                _facebookAPI.UploadPhoto(albumId, uploadFile);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    UploadPhoto(albumId, uploadFile);
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Add tag to a photo.  Only allowed on photos in pending state.
        /// </summary>
        /// <param name="photoId">The id of the photo to tag</param>
        /// <param name="tagText">The text of the tag.  Need to specify either this of tagUserId</param>
        /// <param name="tagUserId">The facebook id the person that was tagged</param>
        /// <param name="xCoord">The x position of the tag on the photo</param>
        /// <param name="yCoord">The y position of the tag on the photo</param>
        public void AddTag(string photoId, string tagText, string tagUserId, int xCoord, int yCoord) {
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            try {
                _facebookAPI.AddTag(photoId, tagText, tagUserId, xCoord, yCoord);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    AddTag(photoId, tagText, tagUserId, xCoord, yCoord);
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Create Album.
        /// </summary>
        /// <param name="name">The name of the album</param>
        /// <param name="location">The location of the album.  (Optional)</param>
        /// <param name="description">The description of the album.  (Optional)</param>
        public Album CreateAlbum(string name, string location, string description) {
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            Album results = null;
            try {
                results = _facebookAPI.CreateAlbum(name, location, description);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    CreateAlbum(name, location, description);
                }
                else
                {
                    throw;
                }
            }
            return results;
        }

        /// <summary>
        /// Get the groups that the logged in user belongs to
        /// </summary>
        /// <returns>groups</returns>
        public Collection<Group> GetGroups() {
            return GetGroups(_facebookAPI.UserId, null);
        }

        /// <summary>
        /// Get the groups that the specified user belongs to
        /// </summary>
        /// <param name="userId">The id of the user to return groups for</param>
        /// <returns>groups</returns>
        public Collection<Group> GetGroups(string userId) {
            return GetGroups(userId, null);
        }

        /// <summary>
        /// Get the groups for the group list
        /// </summary>
        /// <param name="groupsList">Collection of group ids</param>
        /// <returns>groups</returns>
        public Collection<Group> GetGroups(Collection<string> groupsList) {
            return GetGroups(null, groupsList);
        }

        /// <summary>
        /// Get the groups for the specified user and group list
        /// </summary>
        /// <param name="userId">The id of the user to return groups for</param>
        /// <param name="groupsList">Collection of group ids</param>
        /// <returns>groups</returns>
        public Collection<Group> GetGroups(string userId, Collection<string> groupsList) {
            if (!IsSessionActive() && IsDesktopApplication)
            {
                ConnectToFacebook();
            }
            return _facebookAPI.GetGroups(userId, groupsList);
        }

        /// <summary>
        /// Get the groups for the specified user and group list
        /// </summary>
        /// <param name="userId">The id of the user to return groups for</param>
        /// <param name="groupsList">Collection of group ids</param>
        /// <returns>groups</returns>
        public string GetGroupsXML(string userId, Collection<string> groupsList) {
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            string results = string.Empty;
            try {
                results = _facebookAPI.GetGroupsXML(userId, groupsList);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    GetGroupsXML(userId, groupsList);
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// Get the members of the specified group
        /// </summary>
        /// <param name="groupId">The id of the group to return members for</param>
        /// <returns>Group members (user profiles, and group roles)</returns>
        public Collection<GroupUser> GetGroupMembers(string groupId) {
            if (!IsSessionActive() && IsDesktopApplication)
            {
                ConnectToFacebook();
            }
            return _facebookAPI.GetGroupMembers(groupId);
        }

        /// <summary>
        /// Get the members of the specified group
        /// </summary>
        /// <param name="groupId">The id of the group to return members for</param>
        /// <returns>Group members (user profiles, and group roles)</returns>
        public string GetGroupMembersXML(string groupId) {
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            string results = string.Empty;
            try {
                results = _facebookAPI.GetGroupMembersXML(groupId);
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    GetGroupMembersXML(groupId);
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// Get the facebook user id of the user associated with the current session
        /// </summary>
        /// <returns>facebook userid</returns>
        public string GetLoggedInUser() {
            if (!IsSessionActive() && IsDesktopApplication) {
                ConnectToFacebook();
            }
            string results = string.Empty;
            try {
                results = _facebookAPI.GetLoggedInUser();
            }
            catch (FacebookTimeoutException) {
                _facebookAPI.SessionKey = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    GetLoggedInUser();
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        /// <summary>
        /// Determine if the current user is a user of this application already
        /// </summary>
        /// <returns>facebook userid</returns>
        public bool IsAppAdded()
        {
            if (!IsSessionActive() && IsDesktopApplication)
            {
                ConnectToFacebook();
            }
            bool results = false;
            try
            {
                results = _facebookAPI.IsAppAdded();
            }
            catch (FacebookTimeoutException)
            {
                _facebookAPI.SessionKey = null;
                _facebookAPI.UserId = null;
                if (IsDesktopApplication)
                {
                    ConnectToFacebook();
                    IsAppAdded();
                }
                else
                {
                    throw;
                }
            }

            return results;
        }

        #endregion

        #region Private functions

        private bool IsSessionActive() {
            return _facebookAPI.IsSessionActive();
        }

        #endregion
    }
}