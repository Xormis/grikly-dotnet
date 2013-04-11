namespace Grikly.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int ContactsCount { get; set; }
        public string ProfileImageUrl { get; set; }
        public int CardsCount { get; set; }

        public Card DefaultCard { get; set; }
    }
}