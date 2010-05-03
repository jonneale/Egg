using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Entity
{
    public class PublishImage
    {
        #region Private Data
        private string _imageLocation;
        private string _imageLink;


        #endregion Private Data

        #region Properties
        /// <summary>
        /// The url or facebook photoid of the image
        /// </summary>
        public string ImageLocation
        {
            get { return _imageLocation; }
            set { _imageLocation = value; }
        }
        /// <summary>
        /// The url where clicking the image should go
        /// </summary>
        public string ImageLink
        {
            get { return _imageLink; }
            set { _imageLink = value; }
        }

        #endregion Properties

        /// <summary>
        /// Default constructor
        /// </summary>
        public PublishImage()
        {
        }
        /// <summary>
        /// constructor
        /// </summary>
        public PublishImage(string imageLocation, string imageLink)
        {
            _imageLocation = imageLocation;
            _imageLink = imageLink;
        }
    }
}
