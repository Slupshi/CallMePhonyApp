using CallMePhonyApp.ViewModels;

namespace CallMePhonyApp.Views;

public partial class ServiceDetailsView : ContentPage
{
    private readonly ServiceListViewModel _viewModel;
    private readonly MainViewModel _mainViewModel;

    public ServiceDetailsView(ServiceListViewModel viewModel, MainViewModel mainViewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;

        DeleteButton.IsVisible = mainViewModel.IsAdmin ?? false;
        UpdateButton.IsVisible = mainViewModel.IsAdmin ?? false;
    }

    private async void Delete_Button_Clicked(object sender, EventArgs e)
    {
        await _viewModel.DeleteService();
    }
}