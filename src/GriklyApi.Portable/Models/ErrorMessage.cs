// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorMessage.cs" company="">
//   
// </copyright>
// <summary>
//   The error message.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GriklyApi.Models
{
    /// <summary>
    /// The error message.
    /// </summary>
    public class ErrorMessage
    {
        #region Public Properties

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorMessage"/> class.
        /// </summary>
        public ErrorMessage()
        {
            ModelStateErrors = new List<ModelStateError>();
        }

        /// <summary>
        /// Gets or sets the exception message.
        /// </summary>
        /// <value>
        /// The exception message.
        /// </value>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Gets or sets the exception type.
        /// </summary>
        /// <value>
        /// The type of the exception.
        /// </value>
        public string ExceptionType { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the model state errors.
        /// </summary>
        /// <value>
        /// The model state errors.
        /// </value>
        public IEnumerable<ModelStateError> ModelStateErrors { get; set; }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelStateError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelStateError"/> class.
        /// </summary>
        public ModelStateError()
        {
            Values = new List<string>();
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }
        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>
        /// The values.
        /// </value>
        public List<string> Values { get; set; }
    }
}