// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorMessage.cs" company="">
//   
// </copyright>
// <summary>
//   The error message.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GriklyApi.Models
{
    using System.Collections.Generic;

    /// <summary>
    ///     The error message.
    /// </summary>
    public class ErrorMessage
    {
        #region Public Properties

        public ErrorMessage()
        {
            ModelStateErrors = new List<ModelStateError>();
        }

        /// <summary>
        ///     Gets or sets the exception message.
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        ///     Gets or sets the exception type.
        /// </summary>
        public string ExceptionType { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        public IEnumerable<ModelStateError> ModelStateErrors { get; set; }

        #endregion
    }

    public class ModelStateError
    {
        public ModelStateError()
        {
            Values= new List<string>();
        }

        public string Key { get; set; }
        public List<string> Values { get; set; }
    }
}