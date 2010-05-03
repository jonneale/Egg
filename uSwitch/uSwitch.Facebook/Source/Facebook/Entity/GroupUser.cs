using System;
using System.Collections.ObjectModel;

namespace Facebook.Entity {
    public enum GroupPosition
    {
        Member,
        Admin,
        Owner,
        Officer,
        NotReplied
    }

    [Serializable]
    public class GroupUser
    {
        #region Private Data

        private string _groupId;
        private string _userId;
        private User _user;
        private Collection<GroupPosition> _positions;

        #endregion Private Data

        #region Properties
        /// <summary>
        /// The facebook unique identifier of the group this person belongs to
        /// </summary>
        public string GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }
        /// <summary>
        /// The facebook unique identifier of the user
        /// </summary>
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        /// <summary>
        /// The user profile object representing everything about this person
        /// </summary>
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
        /// <summary>
        /// A collection of the positions this person holds within the group
        /// </summary>
        public Collection<GroupPosition> Positions
        {
            get 
            {
                if (_positions == null)
                {
                    _positions = new Collection<GroupPosition>();
                }
                return _positions; 
            }
        }

        #endregion Properties

        /// <summary>
        /// default constructor
        /// </summary>
        public GroupUser() { }
    }
}