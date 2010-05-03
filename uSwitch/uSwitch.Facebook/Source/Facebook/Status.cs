using System;

namespace Facebook
{
    [Serializable]
    public class Status
    {
#region Private Data
        private string _message;
        private DateTime _time;

#endregion Private Data

#region Properties
        /// <summary>
        /// Message
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        /// <summary>
        /// Time
        /// </summary>
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

#endregion Properties

        /// <summary>
        /// Default constructor
        /// </summary>
        public Status()
        {
        }
    }
}