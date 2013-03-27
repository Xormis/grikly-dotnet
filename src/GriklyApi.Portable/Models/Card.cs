using System.ComponentModel;
using Grikly.Annotations;

namespace Grikly.Models
{
    public class Card : INotifyPropertyChanged
    {
        private int cardId;

        public int CardId
        {
            get { return cardId; }
            set
            {
                bool changed = value != cardId;
                cardId = value;
                if (changed) OnPropertyChanged("CardId");
            }
        }

        private int userId;

        public int UserId
        {
            get { return userId; }
            set
            {
                bool changed = value != userId;
                userId = value;
                if (changed) OnPropertyChanged("UserId");
            }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                bool changed = value != firstName;
                firstName = value;
                if (changed) OnPropertyChanged("FirstName");
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                bool changed = value != lastName;
                lastName = value;
                if (changed) OnPropertyChanged("LastName");
            }
        }

        public string WorkNumber { get; set; }

        public string CellNumber { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }
        private string companyName;

        public string CompanyName
        {
            get { return companyName; }
            set
            {
                bool changed = value != companyName;
                companyName = value;
                if (changed) OnPropertyChanged("CompanyName");
            }
        }
        
        public string CompanyAddress { get; set; }
        public double CompanyLatitude { get; set; }
        public double CompanyLongitude { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyPhone { get; set; }

        public string LogoUrl { get; set; }

        public string QrCodeUrl { get; set; }

        public string QrVCardUrl { get; set; }

        public string VCardUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string Website { get; set; }

        public int SharedCount { get; set; }

        public Contact Contact { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}