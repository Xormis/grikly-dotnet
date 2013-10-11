// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Card.cs" company="">
//   
// </copyright>
// <summary>
//   The card.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Grikly.Models
{
    /// <summary>
    /// The card.
    /// </summary>
    public class Card
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the card id.
        /// </summary>
        public int CardId { get; set; }

        /// <summary>
        /// Gets or sets the cell number.
        /// </summary>
        public string CellNumber { get; set; }

        /// <summary>
        /// Gets or sets the company address.
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// Gets or sets the company fax.
        /// </summary>
        public string CompanyFax { get; set; }

        /// <summary>
        /// Gets or sets the company latitude.
        /// </summary>
        public double CompanyLatitude { get; set; }

        /// <summary>
        /// Gets or sets the company longitude.
        /// </summary>
        public double CompanyLongitude { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the company phone.
        /// </summary>
        public string CompanyPhone { get; set; }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the facebook url.
        /// </summary>
        public string FacebookUrl { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the logo url.
        /// </summary>
        public string LogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the qr code url.
        /// </summary>
        public string QrCodeUrl { get; set; }

        /// <summary>
        /// Gets or sets the qr v card url.
        /// </summary>
        public string QrVCardUrl { get; set; }

        /// <summary>
        /// Gets or sets the shared count.
        /// </summary>
        public int SharedCount { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user profile image url.
        /// </summary>
        public string UserProfileImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the v card url.
        /// </summary>
        public string VCardUrl { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the work number.
        /// </summary>
        public string WorkNumber { get; set; }

        #endregion
    }
}