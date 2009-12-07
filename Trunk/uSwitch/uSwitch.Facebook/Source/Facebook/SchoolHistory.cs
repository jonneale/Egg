using System;
using System.Collections.ObjectModel;

namespace Facebook
{
    [Serializable]
    public class SchoolHistory
    {
        #region Private Data

        private HighSchool _highSchool;
        private Collection<HigherEducation> _higherEducation;

        #endregion Private Data

        #region Properties

        /// <summary>
        /// The high school data object for the user
        /// </summary>
        public HighSchool HighSchool
        {
            get { return _highSchool; }
            set { _highSchool = value; }
        }

        /// <summary>
        /// Collection of colleges that the user has attended
        /// </summary>
        public Collection<HigherEducation> HigherEducation
        {
            get 
            {
                if (_higherEducation == null)
                    _higherEducation = new Collection<HigherEducation>();

                return _higherEducation; 
            }
        }

        #endregion Properties

        /// <summary>
        /// Default constructor
        /// </summary>
        public SchoolHistory() { }
    }
}