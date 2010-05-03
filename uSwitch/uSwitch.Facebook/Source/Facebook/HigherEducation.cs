using System;
using System.Collections.ObjectModel;

namespace Facebook
{
    [Serializable]
    public class HigherEducation
    {
        #region Enums

        public enum SchoolType
        {
            Unknown,
            College,
            GraduateSchool
        }

        #endregion Enums

        #region Private Data

        private string _school;
        private int _classYear;
        private SchoolType _attendedFor;
        private Collection<string> _concentration;

        #endregion PrivateData

        #region Properties

        /// <summary>
        /// The name of the school
        /// </summary>
        public string School
        {
            get { return _school; }
            set { _school = value; }
        }

        /// <summary>
        /// Whether attending for undergrad or graduate school
        /// </summary>
        public SchoolType AttendedFor
        {
            get { return _attendedFor; }
            set { _attendedFor = value; }
        }

        /// <summary>
        /// Collection of concentrations
        /// </summary>
        public Collection<string> Concentration
        {
            get
            {
                if (_concentration == null)
                    _concentration = new Collection<string>();

                return _concentration; 
            }
        }

        /// <summary>
        /// Graduation year
        /// </summary>
        public int ClassYear
        {
            get { return _classYear; }
            set { _classYear = value; }
        }

        #endregion Properties

        /// <summary>
        /// Default constructor
        /// </summary>
        public HigherEducation()
        {
        }
    }
}
