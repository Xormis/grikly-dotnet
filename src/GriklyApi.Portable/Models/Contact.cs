using System;

namespace Grikly.Models
{
    public class Contact
    {
        /// <summary>
        /// The id of the related card
        /// </summary>
        public int CardId { get; set; }

        public string EventMet { get; set; }

        public string PlaceMet { get; set; }

        public double LatitudeMet { get; set; }

        public double LongitudeMet { get; set; }

        public DateTime DateMet { get; set; }

        public string Comment { get; set; }
    }
}