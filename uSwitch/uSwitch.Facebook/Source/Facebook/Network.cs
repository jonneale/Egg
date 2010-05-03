using System;

namespace Facebook
{
    public enum NetworkType
    {
        Unknown,
        College,
        HighSchool,
        Work,
        Region
    }
    [Serializable]
    public class Network
    {
#region Private Data

        private string _networkId;
        private string _name;
        private NetworkType _type;
        private int _year;
        private string _status;


#endregion Private Data

#region Properties
        /// <summary>
        /// Facebook unique identifier of the network
        /// </summary>
        public string NetworkId
        {
            get { return _networkId; }
            set { _networkId = value; }
        }
        /// <summary>
        /// The name of the network
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// The type of the network (College, High School, Work or Region)
        /// </summary>
        public NetworkType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// The year the network started
        /// </summary>
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        /// <summary>
        /// The status of the network
        /// </summary>
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

#endregion Properties

        /// <summary>
        /// Default constructor
        /// </summary>
        public Network()
        {
        }
    }
}