// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterModel.cs" company="">
//   
// </copyright>
// <summary>
//   The register model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GriklyApi.Models
{
    /// <summary>
    /// The register model.
    /// </summary>
    public class RegisterModel
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
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

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