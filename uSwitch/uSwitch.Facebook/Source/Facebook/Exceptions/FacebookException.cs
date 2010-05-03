using System;
using System.Runtime.Serialization;

namespace Facebook.Exceptions
{
    /// <summary>
    /// Exception raised for core events aka Facebook interaction.
    /// </summary>
    [Serializable]
    public class FacebookException : Exception
    {
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public FacebookException()
            : base()
        { }
        
        /// <summary>
        /// Constructor with Error Message.
        /// </summary>
        public FacebookException(string message)
            : base(message)
        { }

        /// <summary>
        /// Exception constructor with a custom message after catching an exception.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Exception caught.</param>
        public FacebookException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Constructor used for serialization.
        /// </summary>
        /// <param name="si">The info.</param>
        /// <param name="sc">The context.</param>
        protected FacebookException(SerializationInfo si, StreamingContext sc)
            : base(si, sc)
        { }

    }
}
