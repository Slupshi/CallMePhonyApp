using CallMePhonyApp.ViewModels;

namespace CallMePhonyApp.Views;

public partial class UserDetailsView : ContentPage
{
	private readonly UserListViewModel _viewModel;

	public UserDetailsView(UserListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}

	private void Delete_Button_Clicked(object sender, EventArgs e)
	{
		_viewModel.DeleteUser();
	}
}