using CallMePhonyApp.ViewModels;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Views;

public partial class UserList : ContentPage
{
	private readonly UserListViewModel _viewModel;
	private readonly MainViewModel _mainViewModel;

	public UserList(UserListViewModel viewModel, MainViewModel mainViewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
		_mainViewModel = mainViewModel;
	}

	private void UserSearchBar_TextChanged(object sender, TextChangedEventArgs e)
	{
		// Only serach if we type 3 characters or more
		if (UserSearchBar.Text.Length > 2)
		{
			_viewModel.Search(UserSearchBar.Text);
		}
		else
		{
			_viewModel.ResetSearch();
		}
	}

	private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		_viewModel.SelectedUser = e.Item as User;
		await Navigation.PushAsync(new UserDetailsView(_viewModel, _mainViewModel));
	}
}