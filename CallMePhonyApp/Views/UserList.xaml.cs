using CallMePhonyApp.ViewModels;

namespace CallMePhonyApp;

public partial class UserList : ContentPage
{
	private readonly UserListViewModel _viewModel;

	public UserList(UserListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}

	private void UserSearchBar_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (UserSearchBar.Text.Length > 2)
		{
			_viewModel.Search(UserSearchBar.Text);
		}
		else if (UserSearchBar.Text.Length == 0)
		{
			_viewModel.ResetSearch();
		}
	}
}