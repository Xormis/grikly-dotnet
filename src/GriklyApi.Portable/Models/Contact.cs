// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contact.cs" company="">
//   
// </copyright>
// <summary>
//   The contact.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Grikly.Models
{
    using System;

    /// <summary>
    /// The contact.
    /// </summary>
    public class Contact
    {
        #region Public Properties

        /// <summary>
        ///     The id of the related card
        /// </summary>
        public int CardId { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the date met.
        /// </summary>
        public DateTime DateMet { get; set; }

        /// <summary>
        /// Gets or sets the event met.
        /// </summary>
        public string EventMet { get; set; }

        /// <summary>
        /// Gets or sets the latitude met.
        /// </summary>
        public double LatitudeMet { get; set; }

        /// <summary>
        /// Gets or sets the longitude met.
        /// </summary>
        public double LongitudeMet { get; set; }

        /// <summary>
        /// Gets or sets the place met.
        /// </summary>
        public string PlaceMet { get; set; }

        #endregion
    }
}