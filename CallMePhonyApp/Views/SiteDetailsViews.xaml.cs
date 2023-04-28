using CallMePhonyApp.ViewModels;

namespace CallMePhonyApp.Views;

public partial class SiteDetailsViews : ContentPage
{
	private readonly SiteListViewModel _viewModel;
	private readonly MainViewModel _mainViewModel;

	public SiteDetailsViews(SiteListViewModel viewModel, MainViewModel mainViewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;

		DeleteButton.IsVisible = mainViewModel.IsAdmin ?? false;
		UpdateButton.IsVisible = mainViewModel.IsAdmin ?? false;
	}

	private async void Delete_Button_Clicked(object sender, EventArgs e)
	{
		await _viewModel.DeleteSite();
	}

	private async void UpdateButton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new SiteEditView(_viewModel));
	}
}