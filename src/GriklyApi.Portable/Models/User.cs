// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="">
//   
// </copyright>
// <summary>
//   The user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Grikly.Models
{
    /// <summary>
    /// The user.
    /// </summary>
    public class User
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the cards count.
        /// </summary>
        public int CardsCount { get; set; }

        /// <summary>
        /// Gets or sets the contacts count.
        /// </summary>
        public int ContactsCount { get; set; }

        /// <summary>
        /// Gets or sets the default card.
        /// </summary>
        public Card DefaultCard { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the profile image url.
        /// </summary>
        public string ProfileImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        #endregion
    }
}