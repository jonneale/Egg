using System;
using System.Collections.ObjectModel;

namespace Facebook
{
    [Serializable]
    public class Notifications
    {
        #region Private Data
        private int _unreadMessageCount;
        private string _mostRecentMessageId;
        private int _unreadPokeCount;
        private string _mostRecentPokeId;
        private int _unreadShareCount;
        private string _mostRecentShareId;
        private Collection<string> _friendRequests = new Collection<string>();
        private Collection<string> _groupInvites = new Collection<string>();
        private Collection<string> _eventInvites = new Collection<string>();

        #endregion Private Data

        #region Properties
        /// <summary>
        /// </summary>
        public int UnreadMessageCount
        {
            get { return _unreadMessageCount; }
            set { _unreadMessageCount = value; }
        }

        /// <summary>
        /// </summary>
        public string MostRecentMessageId
        {
            get { return _mostRecentMessageId; }
            set { _mostRecentMessageId = value; }
        }
        /// <summary>
        /// </summary>
        public int UnreadPokeCount
        {
            get { return _unreadPokeCount; }
            set { _unreadPokeCount = value; }
        }

        /// <summary>
        /// </summary>
        public string MostRecentPokeId
        {
            get { return _mostRecentPokeId; }
            set { _mostRecentPokeId = value; }
        }
        /// <summary>
        /// </summary>
        public int UnreadShareCount
        {
            get { return _unreadShareCount; }
            set { _unreadShareCount = value; }
        }

        /// <summary>
        /// </summary>
        public string MostRecentShareId
        {
            get { return _mostRecentShareId; }
            set { _mostRecentShareId = value; }
        }
        /// <summary>
        /// </summary>
        public Collection<string> FriendRequests
        {
            get { return _friendRequests; }
        }
        /// <summary>
        /// </summary>
        public Collection<string> GroupInvites
        {
            get { return _groupInvites; }
        }
        /// <summary>
        /// </summary>
        public Collection<string> EventInvites
        {
            get { return _eventInvites; }
        }

        #endregion Properties

    }
}