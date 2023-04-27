using CallMePhonyApp.ViewModels;

namespace CallMePhonyApp.Views;

public partial class UserDetailsView : ContentPage
{
	private readonly UserListViewModel _viewModel;

	public UserDetailsView(UserListViewModel viewModel, MainViewModel mainViewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;

		DeleteButton.IsVisible = mainViewModel.IsAdmin ?? false;
		UpdateButton.IsVisible = mainViewModel.IsAdmin ?? false;
	}

	private void Delete_Button_Clicked(object sender, EventArgs e)
	{
		_viewModel.DeleteUser();
	}
}