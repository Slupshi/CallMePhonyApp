using CallMePhonyApp.ViewModels;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Views;

public partial class UserList : ContentPage
{
	private readonly UserListViewModel _viewModel;
	private readonly MainViewModel _mainViewModel;
	private readonly SiteListViewModel _siteViewModel;
	private readonly ServiceListViewModel _serviceViewModel;

	public UserList(UserListViewModel viewModel, MainViewModel mainViewModel, SiteListViewModel siteListViewModel, ServiceListViewModel serviceListViewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
		_mainViewModel = mainViewModel;
		_siteViewModel = siteListViewModel;
		_serviceViewModel = serviceListViewModel;
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

	private async void Add_Button_Clicked(object sender, EventArgs e)
	{
		if (_mainViewModel.IsAdmin ?? false)
		{
			await Navigation.PushAsync(new UserCreationView(_viewModel, _siteViewModel.Sites, _serviceViewModel.Services));
		}
	}
}