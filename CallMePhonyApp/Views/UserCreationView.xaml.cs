using CallMePhonyApp.ViewModels;
using CallMePhonyEntities.Enums;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Views;

public partial class UserCreationView : ContentPage
{
    private readonly UserListViewModel _viewModel;
    private readonly IEnumerable<Site> _sites;
    private readonly IEnumerable<Service> _services;

    public UserCreationView(UserListViewModel viewModel, IEnumerable<Site> site, IEnumerable<Service> services)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
        _sites = site;
        _services = services;

        SitePicker.ItemsSource = (System.Collections.IList)_sites;
        ServicePicker.ItemsSource = (System.Collections.IList)_services;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (FirstNameEntry.Text == null || LastNameEntry.Text == null || GenderEntry.Text == null || PhoneEntry.Text == null || MobilePhoneEntry.Text == null)
        {
            return;
        }
        else if (MailEntry.Text == null || SitePicker.SelectedItem == null || ServicePicker.SelectedItem == null || UserTypePicker.SelectedItem == null)
        {
            return;
        }
        await _viewModel.AddUser(new User()
        {
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text.ToUpper(),
            UserName = $"{FirstNameEntry.Text} {LastNameEntry.Text.ToUpper()}",
            Gender = GenderEntry.Text.ToUpper(),
            Phone = PhoneEntry.Text,
            MobilePhone = MobilePhoneEntry.Text,
            Email = MailEntry.Text,
            Site = SitePicker.SelectedItem as Site,
            Service = ServicePicker.SelectedItem as Service,
            UserType = UserTypePicker.SelectedItem.ToString() == "Admin" ? UserType.Admin : UserType.Visitor,
        });
        ClipboardButton.IsVisible = true;
    }

    private async void CopyToClipboardButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(PasswordSpan.Text);
    }
}