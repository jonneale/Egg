using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Remoting.Messaging;
using Facebook.Entity;

namespace Facebook.Components {
    public sealed class AsyncFacebookService : FacebookService
    {
        #region Asynchronous GetPhotoAlbums

        public IAsyncResult BeginGetPhotoAlbums(AsyncCallback callBack,Object state) {
            GetPhotoAlbumsDelegate1 d = GetPhotoAlbums;
            IAsyncResult result = d.BeginInvoke(callBack, state);
            return result;
        }
        public IAsyncResult BeginGetPhotoAlbums(string userId, AsyncCallback callBack, Object state)
        {
            GetPhotoAlbumsDelegate2 d = GetPhotoAlbums;
            IAsyncResult result = d.BeginInvoke(userId,callBack, state);
            return result;
        }
        public IAsyncResult BeginGetPhotoAlbums(Collection<string> albumList, AsyncCallback callBack, Object state)
        {
            GetPhotoAlbumsDelegate3 d = GetPhotoAlbums;
            IAsyncResult result = d.BeginInvoke(albumList, callBack, state);
            return result;
        }
        public IAsyncResult BeginGetPhotoAlbums(string userId, Collection<string> albumList, AsyncCallback callBack, Object state)
        {
            GetPhotoAlbumsDelegate4 d = GetPhotoAlbums;
            IAsyncResult result = d.BeginInvoke(userId,albumList, callBack, state);
            return result;
        }
        public Collection<Album> EndGetPhotoAlbums(IAsyncResult result, Object state) {
            Type delegateType = (((AsyncResult) result).AsyncDelegate).GetType();

            if (delegateType == typeof(GetPhotoAlbumsDelegate1))
            {
                GetPhotoAlbumsDelegate1 d = (GetPhotoAlbumsDelegate1) ((AsyncResult) result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else if (delegateType == typeof(GetPhotoAlbumsDelegate2))
            {
                GetPhotoAlbumsDelegate2 d = (GetPhotoAlbumsDelegate2)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else if (delegateType == typeof(GetPhotoAlbumsDelegate3))
            {
                GetPhotoAlbumsDelegate3 d = (GetPhotoAlbumsDelegate3)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else
            {
                GetPhotoAlbumsDelegate4 d = (GetPhotoAlbumsDelegate4)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            
        }

        #endregion Asynchronous GetPhotoAlbums

        #region Asynchronous GetPhotos

        public IAsyncResult BeginGetPhotos(string albumId, AsyncCallback callBack, Object state)
        {
            GetPhotosDelegate1 d = GetPhotos;
            IAsyncResult result = d.BeginInvoke(albumId, callBack, state);
            return result;
        }
        public IAsyncResult BeginGetPhotos(Collection<string> photoList, AsyncCallback callBack, Object state)
        {
            GetPhotosDelegate2 d = GetPhotos;
            IAsyncResult result = d.BeginInvoke(photoList, callBack, state);
            return result;
        }
        public IAsyncResult BeginGetPhotos(User user, AsyncCallback callBack, Object state)
        {
            GetPhotosDelegate3 d = GetPhotos;
            IAsyncResult result = d.BeginInvoke(user, callBack, state);
            return result;
        }
        public IAsyncResult BeginGetPhotos(string albumId, Collection<string> photoList, AsyncCallback callBack, Object state)
        {
            GetPhotosDelegate4 d = GetPhotos;
            IAsyncResult result = d.BeginInvoke(albumId, photoList, callBack, state);
            return result;
        }
        public IAsyncResult BeginGetPhotos(string albumId, Collection<string> photoList, User user, AsyncCallback callBack, Object state)
        {
            GetPhotosDelegate5 d = GetPhotos;
            IAsyncResult result = d.BeginInvoke(albumId, photoList, user, callBack, state);
            return result;
        }
        public Collection<Photo> EndGetPhotos(IAsyncResult result)
        {
            Type delegateType = (((AsyncResult)result).AsyncDelegate).GetType();

            if (delegateType == typeof(GetPhotosDelegate1))
            {
                GetPhotosDelegate1 d = (GetPhotosDelegate1)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else if (delegateType == typeof(GetPhotosDelegate2))
            {
                GetPhotosDelegate2 d = (GetPhotosDelegate2)((AsyncResult)result).AsyncDelegate;
               return d.EndInvoke(result);
            }
            else if (delegateType == typeof(GetPhotosDelegate3))
            {
                GetPhotosDelegate3 d = (GetPhotosDelegate3)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else if (delegateType == typeof(GetPhotosDelegate4))
            {
                GetPhotosDelegate4 d = (GetPhotosDelegate4)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else
            {
                GetPhotosDelegate5 d = (GetPhotosDelegate5)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
        }

        #endregion  Asynchronous GetPhotos

        #region Asynchronous GetUserInfo

        public IAsyncResult BeginGetUserInfo(AsyncCallback callBack, Object state)
        {
            GetUserInfoDelegate1 d = GetUserInfo;
            IAsyncResult result = d.BeginInvoke(callBack, state);
            return result;
        }
        public IAsyncResult BeginGetUserInfo(string userIds, AsyncCallback callBack, Object state)
        {
            GetUserInfoDelegate2 d = GetUserInfo;
            IAsyncResult result = d.BeginInvoke(userIds, callBack, state);
            return result;
        }
        public IAsyncResult BeginGetUserInfo(Collection<string> userIds, AsyncCallback callBack, Object state)
        {
            GetUserInfoDelegate3 d = GetUserInfo;
            IAsyncResult result = d.BeginInvoke(userIds, callBack, state);
            return result;
        }

        public User EndGetUserInfo(IAsyncResult result)
        {
            GetUserInfoDelegate1 d = (GetUserInfoDelegate1)((AsyncResult)result).AsyncDelegate;
            return d.EndInvoke(result);
           
        }
        /// <summary>
        /// this was necessary because GetUserInfo() returns only User information, instead of Collection<User>, so
        /// I had to name it as the following EndGetUserInfoList instead of EndGetUserInfo
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public Collection<User> EndGetUserInfoList(IAsyncResult result)
        {
            Type delegateType = (((AsyncResult)result).AsyncDelegate).GetType();
           
            if (delegateType == typeof(GetUserInfoDelegate2))
            {
                GetUserInfoDelegate2 d = (GetUserInfoDelegate2)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else 
            {
                GetUserInfoDelegate3 d = (GetUserInfoDelegate3)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
           
        }
        #endregion Asynchronous GetUserInfo

        #region Asynchronous GetEvents

        public IAsyncResult BeginGetEvents(AsyncCallback callBack, Object state)
        {
            GetEventsDelegate1 d = GetEvents;
            IAsyncResult result = d.BeginInvoke(callBack, state);
            return result;
        }
        public IAsyncResult BeginGetEvents(string userId, AsyncCallback callBack, Object state)
        {
            GetEventsDelegate2 d = GetEvents;
            IAsyncResult result = d.BeginInvoke(userId, callBack, state);
            return result;
        }
        public IAsyncResult BeginGetEvents(Collection<string> eventList, AsyncCallback callBack, Object state)
        {
            GetEventsDelegate3 d = GetEvents;
            IAsyncResult result = d.BeginInvoke(eventList, callBack, state);
            return result;
        }
        public IAsyncResult BeginGetEvents(Collection<string> eventList, string userId, AsyncCallback callBack, Object state)
        {
            GetEventsDelegate4 d = GetEvents;
            IAsyncResult result = d.BeginInvoke(eventList,userId, callBack, state);
            return result;
        }
        public Collection<FacebookEvent> EndGetEvents(IAsyncResult result)
        {
            Type delegateType = (((AsyncResult)result).AsyncDelegate).GetType();

            if (delegateType == typeof(GetEventsDelegate1))
            {
                GetEventsDelegate1 d = (GetEventsDelegate1)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else if (delegateType == typeof(GetEventsDelegate2))
            {
                GetEventsDelegate2 d = (GetEventsDelegate2)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else if (delegateType == typeof(GetEventsDelegate3))
            {
                GetEventsDelegate3 d = (GetEventsDelegate3)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else 
            {
                GetEventsDelegate4 d = (GetEventsDelegate4)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
        }

        #endregion Asynchronous GetPhotoAlbums

        #region Asynchronous GetGroups

        public IAsyncResult BeginGetGroups(AsyncCallback callBack, Object state)
        {
            GetGroupsDelegate1 d = GetGroups;
            IAsyncResult result = d.BeginInvoke(callBack, state);
            return result;
        }
        public IAsyncResult BeginGetGroups(string userId, AsyncCallback callBack, Object state)
        {
            GetGroupsDelegate2 d = GetGroups;
            IAsyncResult result = d.BeginInvoke(userId, callBack, state);
            return result;
        }
        public IAsyncResult BeginGetGroups(Collection<string> groupsList, AsyncCallback callBack, Object state)
        {
            GetGroupsDelegate3 d = GetGroups;
            IAsyncResult result = d.BeginInvoke(groupsList, callBack, state);
            return result;
        }
        public IAsyncResult BeginGetGroups(string userId, Collection<string> groupsList, AsyncCallback callBack, Object state)
        {
            GetGroupsDelegate4 d = GetGroups;
            IAsyncResult result = d.BeginInvoke(userId,groupsList, callBack, state);
            return result;
        }
        public Collection<Group> EndGetGroups(IAsyncResult result)
        {
            Type delegateType = (((AsyncResult)result).AsyncDelegate).GetType();
            
            if (delegateType == typeof(GetGroupsDelegate1))
            {
                GetGroupsDelegate1 d = (GetGroupsDelegate1)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else if (delegateType == typeof(GetGroupsDelegate2))
            {
                GetGroupsDelegate2 d = (GetGroupsDelegate2)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else if (delegateType == typeof(GetGroupsDelegate3))
            {
                GetGroupsDelegate3 d = (GetGroupsDelegate3)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else
            {
                GetGroupsDelegate4 d = (GetGroupsDelegate4)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
           
           
        }

        #endregion Asynchronous GetGroups

        #region Asynchronous AddTag

        public IAsyncResult BeginAddTag(string photoId, string tagText, string tagUserId, int xCoord, int yCoord, AsyncCallback callBack, Object state)
        {
            AddTagDelegate d = AddTag;
            IAsyncResult result = d.BeginInvoke(photoId, tagText, tagUserId, xCoord, yCoord,callBack, state);
            return result;
        }
        public void EndAddTag(IAsyncResult result) {
            AddTagDelegate d = (AddTagDelegate)((AsyncResult)result).AsyncDelegate;
            d.EndInvoke(result);
        }

        #endregion

        #region Asynchronous AreFriends

        public IAsyncResult BeginAreFriends(string userId1, string userId2, AsyncCallback callBack, Object state)
        {
            AreFriendsDelegate1 d = AreFriends;
            IAsyncResult result = d.BeginInvoke(userId1, userId2, callBack, state);
            return result;
        }
        public IAsyncResult BeginAreFriends(User userId1, User userId2, AsyncCallback callBack, Object state)
        {
            AreFriendsDelegate2 d = AreFriends;
            IAsyncResult result = d.BeginInvoke(userId1, userId2, callBack, state);
            return result;
        }
        public bool EndAreFriends(IAsyncResult result)
        {
            Type delegateType = (((AsyncResult)result).AsyncDelegate).GetType();
            if (delegateType == typeof(AreFriendsDelegate1))
            {
                AreFriendsDelegate1 d = (AreFriendsDelegate1)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else {
                AreFriendsDelegate2 d = (AreFriendsDelegate2)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
        }

        #endregion


        #region Asynchronous ConnectToFacebook

        public IAsyncResult BeginConnectToFacebook(AsyncCallback callBack, Object state)
        {
            ConnectToFacebookDelegate d = ConnectToFacebook;
            IAsyncResult result = d.BeginInvoke(callBack, state);
            return result;
        }
        public void EndConnectToFacebook(IAsyncResult result)
        {
            ConnectToFacebookDelegate d = (ConnectToFacebookDelegate)((AsyncResult)result).AsyncDelegate;
            d.EndInvoke(result);
        }

        #endregion

        #region Asynchronous GetEventMembers
        public IAsyncResult BeginGetEventMembers(string eventId,AsyncCallback callBack, Object state)
        {
            GetEventMembersDelegate d = GetEventMembers;
            IAsyncResult result = d.BeginInvoke(eventId,callBack, state);
            return result;
        }
        public Collection<EventUser> EndGetEventMembers(IAsyncResult result)
        {
            GetEventMembersDelegate d = (GetEventMembersDelegate)((AsyncResult)result).AsyncDelegate;
            return d.EndInvoke(result);
        }
        #endregion

        #region Asynchronous GetFriends
        public IAsyncResult BeginGetFriends(AsyncCallback callBack, Object state)
        {
            GetFriendsDelegate d = GetFriends;
            IAsyncResult result = d.BeginInvoke( callBack, state);
            return result;
        }
        public Collection<User> EndGetFriends(IAsyncResult result)
        {
            GetFriendsDelegate d = (GetFriendsDelegate)((AsyncResult)result).AsyncDelegate;
            return d.EndInvoke(result);
        }
        #endregion

        #region Asynchronous GetFriendsAppUsers
        public IAsyncResult BeginGetFriendsAppUsers(AsyncCallback callBack, Object state)
        {
            GetFriendsAppUsersDelegate d = GetFriendsAppUsers;
            IAsyncResult result = d.BeginInvoke(callBack, state);
            return result;
        }
        public Collection<User> EndGetFriendsAppUsers(IAsyncResult result)
        {
            GetFriendsAppUsersDelegate d = (GetFriendsAppUsersDelegate)((AsyncResult)result).AsyncDelegate;
            return d.EndInvoke(result);
        }
        #endregion


        #region Asynchronous GetFriendsNonAppUsers
        public IAsyncResult BeginGetFriendsNonAppUsers(AsyncCallback callBack, Object state)
        {
            GetFriendsNonAppUsersDelegate d = GetFriendsNonAppUsers;
            IAsyncResult result = d.BeginInvoke(callBack, state);
            return result;
        }
        public Collection<User> EndGetFriendsNonAppUsers(IAsyncResult result)
        {
            GetFriendsNonAppUsersDelegate d = (GetFriendsNonAppUsersDelegate)((AsyncResult)result).AsyncDelegate;
            return d.EndInvoke(result);
        }
        #endregion


        #region Asynchronous GetGroupMembers
        public IAsyncResult BeginGetGroupMembers(string groupId, AsyncCallback callBack, Object state)
        {
            GetGroupMembersDelegate d = GetGroupMembers;
            IAsyncResult result = d.BeginInvoke(groupId, callBack, state);
            return result;
        }
        public Collection<GroupUser> EndGetGroupMembers(IAsyncResult result)
        {
            GetGroupMembersDelegate d = (GetGroupMembersDelegate)((AsyncResult)result).AsyncDelegate;
            return d.EndInvoke(result);
        }
        #endregion

        #region Asynchronous GetLoggedInUser
        public IAsyncResult BeginGetLoggedInUser(AsyncCallback callBack, Object state)
        {
            GetLoggedInUserDelegate d = GetLoggedInUser;
            IAsyncResult result = d.BeginInvoke(callBack, state);
            return result;
        }
        public string EndGetLoggedInUser(IAsyncResult result)
        {
            GetLoggedInUserDelegate d = (GetLoggedInUserDelegate)((AsyncResult)result).AsyncDelegate;
            return d.EndInvoke(result);
        }
        #endregion

        #region Asynchronous GetNotifications
        public IAsyncResult BeginGetNotifications(AsyncCallback callBack, Object state)
        {
            GetNotificationsDelegate d = GetNotifications;
            IAsyncResult result = d.BeginInvoke(callBack, state);
            return result;
        }
        public Notifications EndGetNotifications(IAsyncResult result)
        {
            GetNotificationsDelegate d = (GetNotificationsDelegate)((AsyncResult)result).AsyncDelegate;
            return d.EndInvoke(result);
        }
        #endregion


        #region Asynchronous PublishAction

        public IAsyncResult BeginPublishAction(string title, string body, Collection<PublishImage> images, AsyncCallback callBack, Object state)
        {
            PublishActionDelegate1 d = PublishAction;
            IAsyncResult result = d.BeginInvoke(title,  body,  images, callBack, state);
            return result;
        }
        public IAsyncResult BeginPublishAction(string title, string body, Collection<PublishImage> images, int priority, AsyncCallback callBack, Object state)
        {
            PublishActionDelegate2 d = PublishAction;
            IAsyncResult result = d.BeginInvoke(title, body, images, priority, callBack, state);
            return result;
        }
        public string EndPublishAction(IAsyncResult result)
        {
            Type delegateType = (((AsyncResult)result).AsyncDelegate).GetType();
            if (delegateType == typeof(PublishActionDelegate1))
            {
                PublishActionDelegate1 d = (PublishActionDelegate1)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else
            {
                PublishActionDelegate2 d = (PublishActionDelegate2)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
        }

        #endregion

        #region Asynchronous PublishStory

        public IAsyncResult BeginPublishStory(string title, string body, Collection<PublishImage> images, AsyncCallback callBack, Object state)
        {
            PublishStoryDelegate1 d = PublishStory;
            IAsyncResult result = d.BeginInvoke(title, body, images, callBack, state);
            return result;
        }
        public IAsyncResult BeginPublishStory(string title, string body, Collection<PublishImage> images, int priority, AsyncCallback callBack, Object state)
        {
            PublishStoryDelegate2 d = PublishStory;
            IAsyncResult result = d.BeginInvoke(title, body, images, priority, callBack, state);
            return result;
        }
        public string EndPublishStory(IAsyncResult result)
        {
            Type delegateType = (((AsyncResult)result).AsyncDelegate).GetType();
            if (delegateType == typeof(PublishStoryDelegate1))
            {
                PublishStoryDelegate1 d = (PublishStoryDelegate1)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
            else
            {
                PublishStoryDelegate2 d = (PublishStoryDelegate2)((AsyncResult)result).AsyncDelegate;
                return d.EndInvoke(result);
            }
        }

        #endregion


        #region Asynchronous GetTags
        public IAsyncResult BeginGetTags(Collection<string> photoList,AsyncCallback callBack, Object state)
        {
            GetTagsDelegate d = GetTags;
            IAsyncResult result = d.BeginInvoke(photoList,callBack, state);
            return result;
        }
        public Collection<PhotoTag> EndGetTags(IAsyncResult result)
        {
            GetTagsDelegate d = (GetTagsDelegate)((AsyncResult)result).AsyncDelegate;
            return d.EndInvoke(result);
        }
        #endregion

        #region Asynchronous SendNotification
        public IAsyncResult BeginSendNotification(string markup, string toList, string email, AsyncCallback callBack, Object state)
        {
            SendNotificationDelegate d = SendNotification;
            IAsyncResult result = d.BeginInvoke(markup,toList,email, callBack, state);
            return result;
        }
        public string EndSendNotification(IAsyncResult result)
        {
            SendNotificationDelegate d = (SendNotificationDelegate)((AsyncResult)result).AsyncDelegate;
            return d.EndInvoke(result);
        }
        #endregion

        #region Asynchronous SendRequest
        public IAsyncResult BeginSendRequest(string markup, string toList, string requestType, Uri imageUrl, bool isInvite, AsyncCallback callBack, Object state)
        {
            SendRequestDelegate d = SendRequest;
            IAsyncResult result = d.BeginInvoke(markup, toList, requestType, imageUrl, isInvite, callBack, state);
            return result;
        }
        public string EndSendRequest(IAsyncResult result)
        {
            SendRequestDelegate d = (SendRequestDelegate)((AsyncResult)result).AsyncDelegate;
            return d.EndInvoke(result);
        }
        #endregion

        #region Asynchronous UploadPhoto
        public IAsyncResult BeginUploadPhoto(string albumId, FileInfo uploadFile, AsyncCallback callBack, Object state)
        {
            UploadPhotoDelegate d = UploadPhoto;
            IAsyncResult result = d.BeginInvoke(albumId, uploadFile, callBack, state);
            return result;
        }
        public void EndUploadPhoto(IAsyncResult result)
        {
            UploadPhotoDelegate d = (UploadPhotoDelegate)((AsyncResult)result).AsyncDelegate;
            d.EndInvoke(result);
        }
        #endregion

        #region Asynchronous CreateAlbum
        public IAsyncResult BeginCreateAlbum(string name, string location, string description, AsyncCallback callBack, Object state)
        {
            CreateAlbumDelegate d = CreateAlbum;
            IAsyncResult result = d.BeginInvoke(name, location, description,callBack, state);
            return result;
        }
        public void EndCreateAlbum(IAsyncResult result)
        {
            CreateAlbumDelegate d = (CreateAlbumDelegate)((AsyncResult)result).AsyncDelegate;
            d.EndInvoke(result);
        }
        #endregion

        #region Delegates GetPhotoAlbums

        private delegate Collection<Album> GetPhotoAlbumsDelegate1();
        private delegate Collection<Album> GetPhotoAlbumsDelegate2(string userId);
        private delegate Collection<Album> GetPhotoAlbumsDelegate3(Collection<string> albumList);
        private delegate Collection<Album> GetPhotoAlbumsDelegate4(string userId, Collection<string> albumList);
        #endregion

        #region Delegates GetPhoto 

        private delegate Collection<Photo> GetPhotosDelegate1(string albumId);
        private delegate Collection<Photo> GetPhotosDelegate2(Collection<string> photoList);
        private delegate Collection<Photo> GetPhotosDelegate3(User user);
        private delegate Collection<Photo> GetPhotosDelegate4(string albumId, Collection<string> photoList);
        private delegate Collection<Photo> GetPhotosDelegate5(string albumId, Collection<string> photoList, User user);
        #endregion

        #region Delegates GetUserInfo 

        private delegate User GetUserInfoDelegate1();
        private delegate Collection<User> GetUserInfoDelegate2(string userIds);
        private delegate Collection<User> GetUserInfoDelegate3(Collection<string> userIds);
        
        #endregion

        #region Delegates GetEvents 

        private delegate Collection<FacebookEvent> GetEventsDelegate1();
        private delegate Collection<FacebookEvent> GetEventsDelegate2(string userId);
        private delegate Collection<FacebookEvent> GetEventsDelegate3(Collection<string> eventList);
        private delegate Collection<FacebookEvent> GetEventsDelegate4(Collection<string> eventList,string userId);
        #endregion

        #region Delegates GetGroups

        private delegate Collection<Group> GetGroupsDelegate1();
        private delegate Collection<Group> GetGroupsDelegate2(string userId);
        private delegate Collection<Group> GetGroupsDelegate3(Collection<string> groupsList);
        private delegate Collection<Group> GetGroupsDelegate4(string userId, Collection<string> groupsList);
        #endregion

        #region  Delegates AreFriends
        private delegate bool AreFriendsDelegate1(string userId1, string userId2);
        private delegate bool AreFriendsDelegate2(User userId1, User userId2);  
        #endregion
        
        #region  Delegates PublishAction
        private delegate string PublishActionDelegate1(string title, string body, Collection<PublishImage> images);
        private delegate string PublishActionDelegate2(string title, string body, Collection<PublishImage> images, int priority);
        #endregion

        #region  Delegates PublishStory
        private delegate string PublishStoryDelegate1(string title, string body, Collection<PublishImage> images);
        private delegate string PublishStoryDelegate2(string title, string body, Collection<PublishImage> images, int priority);
        #endregion

        #region Delegates Single method calls

        private delegate void AddTagDelegate(string photoId, string tagText, string tagUserId, int xCoord, int yCoord);
        private delegate void ConnectToFacebookDelegate();
        private delegate Collection<EventUser> GetEventMembersDelegate(string eventId);
        private delegate Collection<User> GetFriendsDelegate();
        private delegate Collection<User> GetFriendsAppUsersDelegate();
        private delegate Collection<User> GetFriendsNonAppUsersDelegate();
        private delegate Collection<GroupUser> GetGroupMembersDelegate(string groupId);
        private delegate string GetLoggedInUserDelegate();
        private delegate Notifications GetNotificationsDelegate();
        private delegate Collection<PhotoTag> GetTagsDelegate(Collection<string> photoList);
        private delegate string SendNotificationDelegate(string markup, string toList, string email);
        private delegate string SendRequestDelegate(string markup, string toList, string requestType, Uri imageUrl, bool isInvite);
        private delegate void UploadPhotoDelegate(string albumId, FileInfo uploadFile);
        private delegate Album CreateAlbumDelegate(string name, string location, string description);
        #endregion

        
    }
}