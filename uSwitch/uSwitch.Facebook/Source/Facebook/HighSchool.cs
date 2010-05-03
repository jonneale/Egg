using System;

namespace Facebook
{
    [Serializable]
    public class HighSchool
    {
        #region Private Data

        private string _highSchoolOneName;
        private string _highSchoolTwoName;
        private string _highSchoolOneId;
        private string _highSchoolTwoId;
        private int _graduationYear;

        #endregion PrivateData

        #region Properties
        /// <summary>
        /// The name of the first high school attended
        /// </summary>
        public string HighSchoolOneName
        {
            get { return _highSchoolOneName; }
            set { _highSchoolOneName = value; }
        }

        /// <summary>
        /// The name of the second high school attended
        /// </summary>
        public string HighSchoolTwoName
        {
            get { return _highSchoolTwoName; }
            set { _highSchoolTwoName = value; }
        }

        /// <summary>
        /// The facebook unique identifier of the first high school attended
        /// </summary>
        public string HighSchoolOneId
        {
            get { return _highSchoolOneId; }
            set { _highSchoolOneId = value; }
        }

        /// <summary>
        /// The facebook unique identifier of the second high school attended
        /// </summary>
        public string HighSchoolTwoId
        {
            get { return _highSchoolTwoId; }
            set { _highSchoolTwoId = value; }
        }

        /// <summary>
        /// The year this person graduated from high school
        /// </summary>
        public int GraduationYear
        {
            get { return _graduationYear; }
            set { _graduationYear = value; }
        }
        #endregion Properties

        /// <summary>
        /// Default constructor
        /// </summary>
        public HighSchool()
        {
        }
    }
}
