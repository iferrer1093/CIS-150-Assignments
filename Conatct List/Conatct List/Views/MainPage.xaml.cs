using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Contacts_List
{
    public sealed partial class MainPage : Page
    {
        public ContactsViewModel ViewModel { get; set; } = new ContactsViewModel();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text) && !string.IsNullOrWhiteSpace(PhoneTextBox.Text))
            {
                ViewModel.Contacts.Add(new Contact
                {
                    Name = NameTextBox.Text,
                    PhoneNumber = PhoneTextBox.Text
                });

                NameTextBox.Text = "";
                PhoneTextBox.Text = "";
            }
            else
            {
                var dialog = new ContentDialog
                {
                    Title = "Input Error",
                    Content = "Please enter both name and phone number.",
                    CloseButtonText = "OK"
                };
                _ = dialog.ShowAsync();
            }
        }

        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedContact != null)
            {
                ViewModel.Contacts.Remove(ViewModel.SelectedContact);
            }
            else
            {
                var dialog = new ContentDialog
                {
                    Title = "Selection Error",
                    Content = "Please select a contact to delete.",
                    CloseButtonText = "OK"
                };
                _ = dialog.ShowAsync();
            }
        }
    }
}
