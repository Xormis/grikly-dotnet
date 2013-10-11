// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorMessage.cs" company="">
//   
// </copyright>
// <summary>
//   The error message.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Grikly
{
    /// <summary>
    /// The error message.
    /// </summary>
    public class ErrorMessage
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the exception message.
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Gets or sets the exception type.
        /// </summary>
        public string ExceptionType { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        #endregion
    }
}