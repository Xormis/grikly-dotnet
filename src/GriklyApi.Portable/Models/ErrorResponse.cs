// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorResponse.cs" company="">
//   
// </copyright>
// <summary>
//   The error response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Grikly
{
    using System.Net;

    /// <summary>
    /// The error response.
    /// </summary>
    public class ErrorResponse
    {
        #region Fields

        /// <summary>
        /// The http status code.
        /// </summary>
        public HttpStatusCode HttpStatusCode;

        /// <summary>
        /// The message.
        /// </summary>
        public ErrorMessage Message;

        #endregion
    }
}