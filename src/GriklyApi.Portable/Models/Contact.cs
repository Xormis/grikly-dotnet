// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contact.cs" company="">
//   
// </copyright>
// <summary>
//   The contact.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace GriklyApi.Models
{
    /// <summary>
    /// The contact.
    /// </summary>
    public class Contact
    {
        #region Public Properties

        /// <summary>
        /// The id of the related card
        /// </summary>
        /// <value>
        /// The card identifier.
        /// </value>
        public int CardId { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the date met.
        /// </summary>
        /// <value>
        /// The date met.
        /// </value>
        public DateTime DateMet { get; set; }

        /// <summary>
        /// Gets or sets the event met.
        /// </summary>
        /// <value>
        /// The event met.
        /// </value>
        public string EventMet { get; set; }

        /// <summary>
        /// Gets or sets the latitude met.
        /// </summary>
        /// <value>
        /// The latitude met.
        /// </value>
        public double LatitudeMet { get; set; }

        /// <summary>
        /// Gets or sets the longitude met.
        /// </summary>
        /// <value>
        /// The longitude met.
        /// </value>
        public double LongitudeMet { get; set; }

        /// <summary>
        /// Gets or sets the place met.
        /// </summary>
        /// <value>
        /// The place met.
        /// </value>
        public string PlaceMet { get; set; }

        #endregion
    }
}