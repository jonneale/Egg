using System;
using System.Xml.Linq;
using System.Collections.Generic;
namespace Facebook.Extended
{
	public interface IFacebookApi
	{
		void AddTag(string photoId, string tagText, string tagUserId, int xCoord, int yCoord);
		string ApplicationKey { get; set; }
		bool AreFriends(Facebook.Entity.User user1, Facebook.Entity.User user2);
		bool AreFriends(string userId1, string userId2);
		string AuthToken { get; set; }
		Facebook.Entity.Album CreateAlbum(string name, string location, string description);
		void CreateSession(string authToken);
		string DirectFQLQuery(string query);
		System.Collections.ObjectModel.Collection<Facebook.Entity.EventUser> GetEventMembers(string eventId);
		string GetEventMembersXML(string eventId);
		System.Collections.ObjectModel.Collection<Facebook.Entity.FacebookEvent> GetEvents(System.Collections.ObjectModel.Collection<string> eventList, string userId);
		System.Collections.ObjectModel.Collection<Facebook.Entity.FacebookEvent> GetEvents(System.Collections.ObjectModel.Collection<string> eventList, string userId, DateTime? startDate, DateTime? endDate);
		System.Collections.ObjectModel.Collection<Facebook.Entity.FacebookEvent> GetEvents(System.Collections.ObjectModel.Collection<string> eventList);
		System.Collections.ObjectModel.Collection<Facebook.Entity.FacebookEvent> GetEvents();
		System.Collections.ObjectModel.Collection<Facebook.Entity.FacebookEvent> GetEvents(string userId);
		string GetEventsXML(System.Collections.ObjectModel.Collection<string> eventList, string userId, DateTime? startDate, DateTime? endDate);
		System.Collections.ObjectModel.Collection<string> GetFriendIds();
		System.Collections.ObjectModel.Collection<Facebook.Entity.User> GetFriends();
		System.Collections.ObjectModel.Collection<Facebook.Entity.User> GetFriendsAppUsers();
		string GetFriendsAppUsersXML();
		System.Collections.ObjectModel.Collection<Facebook.Entity.User> GetFriendsNonAppUsers();
		string GetFriendsXML();
		System.Collections.ObjectModel.Collection<Facebook.Entity.GroupUser> GetGroupMembers(string groupId);
		string GetGroupMembersXML(string groupId);
		System.Collections.ObjectModel.Collection<Facebook.Entity.Group> GetGroups();
		System.Collections.ObjectModel.Collection<Facebook.Entity.Group> GetGroups(string userId, System.Collections.ObjectModel.Collection<string> groupsList);
		System.Collections.ObjectModel.Collection<Facebook.Entity.Group> GetGroups(System.Collections.ObjectModel.Collection<string> groupsList);
		System.Collections.ObjectModel.Collection<Facebook.Entity.Group> GetGroups(string userId);
		string GetGroupsXML(string userId, System.Collections.ObjectModel.Collection<string> groupsList);
		string GetLoggedInUser();
		Facebook.Entity.Notifications GetNotifications();
		string GetNotificationsXml();
		System.Collections.ObjectModel.Collection<Facebook.Entity.Album> GetPhotoAlbums();
		System.Collections.ObjectModel.Collection<Facebook.Entity.Album> GetPhotoAlbums(System.Collections.ObjectModel.Collection<string> albumList);
		System.Collections.ObjectModel.Collection<Facebook.Entity.Album> GetPhotoAlbums(string userId);
		System.Collections.ObjectModel.Collection<Facebook.Entity.Album> GetPhotoAlbums(string userId, System.Collections.ObjectModel.Collection<string> albumList);
		string GetPhotoAlbumsXML(string userId, System.Collections.ObjectModel.Collection<string> albumList);
		System.Collections.ObjectModel.Collection<Facebook.Entity.Photo> GetPhotos(string albumId);
		System.Collections.ObjectModel.Collection<Facebook.Entity.Photo> GetPhotos(Facebook.Entity.User user);
		System.Collections.ObjectModel.Collection<Facebook.Entity.Photo> GetPhotos(System.Collections.ObjectModel.Collection<string> photoList);
		System.Collections.ObjectModel.Collection<Facebook.Entity.Photo> GetPhotos(string albumId, System.Collections.ObjectModel.Collection<string> photoList, Facebook.Entity.User user);
		System.Collections.ObjectModel.Collection<Facebook.Entity.Photo> GetPhotos(string albumId, System.Collections.ObjectModel.Collection<string> photoList);
		string GetPhotosXML(string albumId, System.Collections.ObjectModel.Collection<string> photoList);
		string GetPhotosXML(string albumId, System.Collections.ObjectModel.Collection<string> photoList, Facebook.Entity.User user);
		System.Collections.ObjectModel.Collection<Facebook.Entity.PhotoTag> GetTags(System.Collections.ObjectModel.Collection<string> photoList);
		string GetTagsXML(System.Collections.ObjectModel.Collection<string> photoList);
		System.Collections.ObjectModel.Collection<Facebook.Entity.User> GetUserInfo(string userIds);
		Facebook.Entity.User GetUserInfo();
		System.Collections.ObjectModel.Collection<Facebook.Entity.User> GetUserInfo(System.Collections.ObjectModel.Collection<string> userIds);
		string GetUserInfoXml(string userIds);
		bool IsAppAdded();
		bool IsDesktopApplication { get; set; }
		System.Xml.XmlNamespaceManager NsManager { get; }
		string PublishAction(string title, string body, System.Collections.ObjectModel.Collection<Facebook.Entity.PublishImage> images, int priority);
		string PublishAction(string title, string body, System.Collections.ObjectModel.Collection<Facebook.Entity.PublishImage> images);
		string PublishStory(string title, string body, System.Collections.ObjectModel.Collection<Facebook.Entity.PublishImage> images);
		string PublishStory(string title, string body, System.Collections.ObjectModel.Collection<Facebook.Entity.PublishImage> images, int priority);
		string Secret { get; set; }
		string SendNotification(string markup, string toList, string email);
		string SendNotification(string markup, string toList);
		string SendRequest(string markup, string toList, string requestType, Uri imageUrl, bool isInvite);
		bool SessionExpires { get; }
		string SessionKey { get; set; }
		string SetFBML(string markup);
		string SetFBML(string markup, string userId);
		void UploadPhoto(string albumId, System.IO.FileInfo uploadFile);
		string UserId { get; set; }
		XDocument ExecuteApiRequest(IDictionary<string, string> parameterDictionary, bool useSession);
	}
}
