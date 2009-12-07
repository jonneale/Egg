using System;

namespace Facebook.Entity {
    [Serializable]
    public class PhotoTag
    {
        #region Private Data
        private string _photoId;
        private string _subjectUserId;
        private double _xCoord;
        private double _yCoord;


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
        /// The facebook unique identifier of the user the tag points to
        /// </summary>
        public string SubjectUserId
        {
            get { return _subjectUserId; }
            set { _subjectUserId = value; }
        }

        /// <summary>
        /// The x coordinate within the picture of the location of the tag
        /// </summary>
        public double XCoord
        {
            get { return _xCoord; }
            set { _xCoord = value; }
        }

        /// <summary>
        /// The y coordinate within the picture of the location of the tag
        /// </summary>
        public double YCoord
        {
            get { return _yCoord; }
            set { _yCoord = value; }
        }

        #endregion Properties

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PhotoTag()
        {
        }
    }
}