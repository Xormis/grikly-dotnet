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
    ///     The register model.
    /// </summary>
    public class RegisterModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        #endregion
    }
}