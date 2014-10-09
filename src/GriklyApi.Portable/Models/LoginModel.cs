// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginModel.cs" company="">
//   
// </copyright>
// <summary>
//   The login model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GriklyApi.Models
{
    /// <summary>
    /// The login model.
    /// </summary>
    public class LoginModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        #endregion
    }
}