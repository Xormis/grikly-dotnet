// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorResponse.cs" company="">
//   
// </copyright>
// <summary>
//   The error response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GriklyApi.Models
{
    using System.Net;

    /// <summary>
    ///     The error response.
    /// </summary>
    public class ErrorResponse
    {
        #region Public Properties

        /// <summary>
        ///     The http status code.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        ///     The message.
        /// </summary>
        public ErrorMessage ErrorMessage { get; set; }

        #endregion
    }
}