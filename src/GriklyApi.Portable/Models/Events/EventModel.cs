using System;

namespace GriklyApi.Models.Events
{
    /// <summary>
    ///     Model for event
    /// </summary>
    public class EventModel
    {
        /// <summary>
        ///     Gets or sets the event identifier.
        /// </summary>
        /// <value>
        ///     The event identifier.
        /// </value>
        public virtual Guid EventId { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public virtual string Title { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public virtual string Description { get; set; }

        /// <summary>
        ///     Gets or sets the start.
        /// </summary>
        /// <value>
        ///     The start.
        /// </value>
        public virtual DateTime Start { get; set; }

        /// <summary>
        ///     Gets or sets the end.
        /// </summary>
        /// <value>
        ///     The end.
        /// </value>
        public virtual DateTime End { get; set; }

        /// <summary>
        ///     Gets or sets the street.
        /// </summary>
        /// <value>
        ///     The street.
        /// </value>
        public virtual string Street { get; set; }

        /// <summary>
        ///     Gets or sets the route.
        /// </summary>
        /// <value>
        ///     The route.
        /// </value>
        public virtual string Route { get; set; }

        /// <summary>
        ///     Gets or sets the city.
        /// </summary>
        /// <value>
        ///     The city.
        /// </value>
        public virtual string City { get; set; }

        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        /// <value>
        ///     The state.
        /// </value>
        public virtual string State { get; set; }

        /// <summary>
        ///     Gets or sets the zip code.
        /// </summary>
        /// <value>
        ///     The zip code.
        /// </value>
        public virtual string ZipCode { get; set; }

        /// <summary>
        ///     Gets or sets the country.
        /// </summary>
        /// <value>
        ///     The country.
        /// </value>
        public virtual string Country { get; set; }

        /// <summary>
        ///     Gets or sets the latitude.
        /// </summary>
        /// <value>
        ///     The latitude.
        /// </value>
        public virtual double Latitude { get; set; }

        /// <summary>
        ///     Gets or sets the longitutude.
        /// </summary>
        /// <value>
        ///     The longitutude.
        /// </value>
        public virtual double Longitutude { get; set; }

        /// <summary>
        ///     Gets or sets the website URL.
        /// </summary>
        /// <value>
        ///     The website URL.
        /// </value>
        public virtual string WebsiteUrl { get; set; }

        /// <summary>
        ///     Gets or sets the facebook URL.
        /// </summary>
        /// <value>
        ///     The facebook URL.
        /// </value>
        public virtual string FacebookUrl { get; set; }

        /// <summary>
        ///     Gets or sets the twitter URL.
        /// </summary>
        /// <value>
        ///     The twitter URL.
        /// </value>
        public virtual string TwitterUrl { get; set; }
    }
}