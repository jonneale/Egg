using System;

namespace Facebook
{
    [Serializable]
    public class Album
    {
#region Private Data
        private string _albumId;
        private string _coverPhotoId;
        private string _ownerUserId;
        private string _name;
        private DateTime _createDate;
        private DateTime _modifiedDate;
        private string _description;
        private string _location;

#endregion Private Data

#region Properties
        /// <summary>
        /// The facebook unique identifier of the album
        /// </summary>
        public string AlbumId
        {
            get { return _albumId; }
            set { _albumId = value; }
        }

        /// <summary>
        /// The facebook unique identifier of the photo that is the cover photo for this album
        /// </summary>
        public string CoverPhotoId
        {
            get { return _coverPhotoId; }
            set { _coverPhotoId = value; }
        }

        /// <summary>
        /// The facebook unique identifier of the user that created the album
        /// </summary>
        public string OwnerUserId
        {
            get { return _ownerUserId; }
            set { _ownerUserId = value; }
        }

        /// <summary>
        /// The name of the album
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// The date the album was created
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        /// <summary>
        /// The date the album was last updated
        /// </summary>
        public DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }

        /// <summary>
        /// The description of the album
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// The location where the pictures took place
        /// </summary>
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }



#endregion Properties

        /// <summary>
        /// Default constructor
        /// </summary>
        public Album()
        {
        }
    }
}