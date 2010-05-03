using System;
using Facebook.Entity;

namespace Facebook.Entity {
    [Serializable]
    public class Work
    {
        #region Private Data
        private Location _location;
        private string _companyName;
        private string _position;
        private string _description;
        private DateTime _startDate;
        private DateTime _endDate;

        #endregion Private Data

        #region Properties
        /// <summary>
        /// city/state where work took place
        /// </summary>
        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

        /// <summary>
        /// The name of the company
        /// </summary>
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        /// <summary>
        /// The person's job title
        /// </summary>
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }

        /// <summary>
        /// description of job
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// date person started the job
        /// </summary>
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        /// <summary>
        /// date person ended the job
        /// </summary>
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        #endregion Properties

    }
}