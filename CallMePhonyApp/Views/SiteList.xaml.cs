using CallMePhonyApp.ViewModels;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Views;

public partial class SiteList : ContentPage
{
	private readonly SiteListViewModel _viewModel;
	private readonly MainViewModel _mainViewModel;

	public SiteList(SiteListViewModel viewModel, MainViewModel mainViewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
		_mainViewModel = mainViewModel;
	}

	private void SiteSearchBar_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (SiteSearchBar.Text.Length > 2)
		{
			_viewModel.Search(SiteSearchBar.Text);
		}
		else
		{
			_viewModel.ResetSearch();
		}
	}

	private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		_viewModel.SelectedSite = e.Item as Site;
		await Navigation.PushAsync(new SiteDetailsViews(_viewModel, _mainViewModel));
	}
}