using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GriklyApi.Models
{
    /// <summary>
    /// Model for event
    /// </summary>
    public class EventModel
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        public DateTime Start { get; set; }
        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>
        /// The end.
        /// </value>
        public DateTime End { get; set; }
        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        public string Street { get; set; }
        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        /// <value>
        /// The route.
        /// </value>
        public string Route { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string State { get; set; }
        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        public string ZipCode { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }
    }
}
