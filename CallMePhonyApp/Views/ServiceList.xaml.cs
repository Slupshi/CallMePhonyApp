using CallMePhonyApp.ViewModels;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Views;

public partial class ServiceList : ContentPage
{
    private readonly ServiceListViewModel _viewModel;
    private readonly MainViewModel _mainViewModel;

    public ServiceList(ServiceListViewModel viewModel, MainViewModel mainViewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
        _mainViewModel = mainViewModel;

        AddButton.IsVisible = _mainViewModel.IsAdmin ?? false;
    }

    private void ServiceSearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (ServiceSearchBar.Text.Length > 2)
        {
            _viewModel.Search(ServiceSearchBar.Text);
        }
        else
        {
            _viewModel.ResetSearch();
        }
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        _viewModel.SelectedService = e.Item as Service;
        await Navigation.PushAsync(new ServiceDetailsView(_viewModel, _mainViewModel));
    }

    private async void Add_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ServiceCreationView(_viewModel));
    }
}