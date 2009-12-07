using System;
using System.Runtime.Serialization;

namespace Facebook.Exceptions
{
    /// <summary>
    /// Exception returned for ERRORNO 102
    /// </summary>
    [Serializable]
    public class FacebookTimeoutException : FacebookException
    {
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public FacebookTimeoutException()
            : base()
        { }

        /// <summary>
        /// Constructor with Error Message.
        /// </summary>
        public FacebookTimeoutException(string message)
            : base(message)
        { }

        /// <summary>
        /// Exception constructor with a custom message after catching an exception.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Exception caught.</param>
        public FacebookTimeoutException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Constructor used for serialization.
        /// </summary>
        /// <param name="si">The info.</param>
        /// <param name="sc">The context.</param>
        protected FacebookTimeoutException(SerializationInfo si, StreamingContext sc)
            : base(si, sc)
        { }
    }
}
