using CallMePhonyApp.ViewModels;

namespace CallMePhonyApp.Views;

public partial class ServiceList : ContentPage
{
    private readonly ServiceListViewModel _viewModel;

    public ServiceList(ServiceListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
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
}