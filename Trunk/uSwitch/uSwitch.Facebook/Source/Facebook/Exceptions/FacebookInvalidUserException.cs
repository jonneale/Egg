using System;
using System.Runtime.Serialization;

namespace Facebook.Exceptions
{
    /// <summary>
    /// Exception returned for ERRORNO 110
    /// </summary>
    [Serializable]
    public class FacebookInvalidUserException : FacebookException
    {
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public FacebookInvalidUserException()
            : base()
        { }

        /// <summary>
        /// Constructor with Error Message.
        /// </summary>
        public FacebookInvalidUserException(string message)
            : base(message)
        { }

        /// <summary>
        /// Exception constructor with a custom message after catching an exception.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Exception caught.</param>
        public FacebookInvalidUserException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Constructor used for serialization.
        /// </summary>
        /// <param name="si">The info.</param>
        /// <param name="sc">The context.</param>
        protected FacebookInvalidUserException(SerializationInfo si, StreamingContext sc)
            : base(si, sc)
        { }
    }
}
