// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Card.cs" company="">
//   
// </copyright>
// <summary>
//   The card.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace GriklyApi.Models
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
        /// <value>
        /// The card identifier.
        /// </value>
        public Guid CardId { get; set; }

        /// <summary>
        /// Gets or sets the company address.
        /// </summary>
        /// <value>
        /// The company address.
        /// </value>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// Gets or sets the company fax.
        /// </summary>
        /// <value>
        /// The company fax.
        /// </value>
        public string CompanyFax { get; set; }

        /// <summary>
        /// Gets or sets the company latitude.
        /// </summary>
        /// <value>
        /// The company latitude.
        /// </value>
        public double CompanyLatitude { get; set; }

        /// <summary>
        /// Gets or sets the company longitude.
        /// </summary>
        /// <value>
        /// The company longitude.
        /// </value>
        public double CompanyLongitude { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }


        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        /// <value>
        /// The contact.
        /// </value>
        public Contact Contact { get; set; }


        /// <summary>
        /// Gets or sets the email addresses.
        /// </summary>
        /// <value>
        /// The email addresses.
        /// </value>
        public IList<ContactEmailAddress> EmailAddresses { get; set; }

        /// <summary>
        /// Gets or sets the facebook url.
        /// </summary>
        /// <value>
        /// The facebook URL.
        /// </value>
        public string FacebookUrl { get; set; }

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
        /// Gets or sets the logo url.
        /// </summary>
        /// <value>
        /// The logo URL.
        /// </value>
        public string LogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        public IList<ContactPhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the qr code url.
        /// </summary>
        /// <value>
        /// The qr code URL.
        /// </value>
        public string QrCodeUrl { get; set; }

        /// <summary>
        /// Gets or sets the qr v card url.
        /// </summary>
        /// <value>
        /// The qr v card URL.
        /// </value>
        public string QrVCardUrl { get; set; }

        /// <summary>
        /// Gets or sets the shared count.
        /// </summary>
        /// <value>
        /// The shared count.
        /// </value>
        public int SharedCount { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user profile image url.
        /// </summary>
        /// <value>
        /// The user profile image URL.
        /// </value>
        public string UserProfileImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the v card url.
        /// </summary>
        /// <value>
        /// The v card URL.
        /// </value>
        public string VCardUrl { get; set; }


        /// <summary>
        /// Gets or sets the websites.
        /// </summary>
        /// <value>
        /// The websites.
        /// </value>
        public IList<ContactWebsite> Websites { get; set; }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class ContactPhoneNumber
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        /// <value>
        /// The kind.
        /// </value>
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; set; }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class ContactWebsite
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        /// <value>
        /// The kind.
        /// </value>
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the website address.
        /// </summary>
        /// <value>
        /// The website address.
        /// </value>
        public string WebsiteAddress { get; set; }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class ContactEmailAddress
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        /// <value>
        /// The kind.
        /// </value>
        public string Kind { get; set; }

        #endregion
    }
}