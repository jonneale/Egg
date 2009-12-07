using System;
using System.ComponentModel;

namespace Facebook {
    public enum RSVPStatus {
        [Description("Not Replied")] not_replied,
        Attending,
        Unsure,
        Declined
    }

    [Serializable]
    public class EventUser {
        #region Private Data

        private string _eventId;
        private string _userId;
        private User _user;
        private RSVPStatus _attending;

        #endregion Private Data

        #region Properties

        /// <summary>
        /// The facebook unique identifier of the event
        /// </summary>
        public string EventId {
            get { return _eventId; }
            set { _eventId = value; }
        }

        /// <summary>
        /// The facebook unique identifier of the user who was invited to the event
        /// </summary>
        public string UserId {
            get { return _userId; }
            set { _userId = value; }
        }

        /// <summary>
        /// The user profile object of the user invited to the event
        /// </summary>
        public User User {
            get { return _user; }
            set { _user = value; }
        }

        /// <summary>
        /// Represents the person's commitment to attend the event or not
        /// </summary>
        public RSVPStatus Attending {
            get { return _attending; }
            set { _attending = value; }
        }

        #endregion Properties

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventUser() {
        }
    }
}