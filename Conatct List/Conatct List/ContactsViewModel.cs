using System.Collections.ObjectModel;

namespace Contacts_List
{
    public class ContactsViewModel
    {
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get => _selectedContact;
            set => _selectedContact = value;
        }
    }
}
