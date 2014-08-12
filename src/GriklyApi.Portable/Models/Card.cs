// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Card.cs" company="">
//   
// </copyright>
// <summary>
//   The card.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GriklyApi.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     The card.
    /// </summary>
    public class Card
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the card id.
        /// </summary>
        public Guid CardId { get; set; }

        /// <summary>
        ///     Gets or sets the company address.
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        ///     Gets or sets the company fax.
        /// </summary>
        public string CompanyFax { get; set; }

        /// <summary>
        ///     Gets or sets the company latitude.
        /// </summary>
        public double CompanyLatitude { get; set; }

        /// <summary>
        ///     Gets or sets the company longitude.
        /// </summary>
        public double CompanyLongitude { get; set; }

        /// <summary>
        ///     Gets or sets the company name.
        /// </summary>
        public string CompanyName { get; set; }


        /// <summary>
        ///     Gets or sets the contact.
        /// </summary>
        public Contact Contact { get; set; }


        public IList<ContactEmailAddress> EmailAddresses { get; set; }

        /// <summary>
        ///     Gets or sets the facebook url.
        /// </summary>
        public string FacebookUrl { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the logo url.
        /// </summary>
        public string LogoUrl { get; set; }

        public IList<ContactPhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        ///     Gets or sets the qr code url.
        /// </summary>
        public string QrCodeUrl { get; set; }

        /// <summary>
        ///     Gets or sets the qr v card url.
        /// </summary>
        public string QrVCardUrl { get; set; }

        /// <summary>
        ///     Gets or sets the shared count.
        /// </summary>
        public int SharedCount { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the user id.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        ///     Gets or sets the user profile image url.
        /// </summary>
        public string UserProfileImageUrl { get; set; }

        /// <summary>
        ///     Gets or sets the v card url.
        /// </summary>
        public string VCardUrl { get; set; }


        public IList<ContactWebsite> Websites { get; set; }

        #endregion
    }

    public class ContactPhoneNumber
    {
        #region Public Properties

        public string Kind { get; set; }

        public string PhoneNumber { get; set; }

        #endregion
    }

    public class ContactWebsite
    {
        #region Public Properties

        public string Kind { get; set; }

        public string WebsiteAddress { get; set; }

        #endregion
    }

    public class ContactEmailAddress
    {
        #region Public Properties

        public string EmailAddress { get; set; }

        public string Kind { get; set; }

        #endregion
    }
}