using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grikly.Models
{
    public class Card
    {
        public int CardId { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string WorkNumber { get; set; }

        public string CellNumber { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string LogoUrl { get; set; }

        public string QrCodeUrl { get; set; }

        public string QrVCardUrl { get; set; }

        public string VCardUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string Website { get; set; }

        public int SharedCount { get; set; }

        public Contact Contact { get; set; }

        public bool IsPrivate { get; set; }
    }
}
