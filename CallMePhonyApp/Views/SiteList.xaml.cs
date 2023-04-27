using CallMePhonyApp.ViewModels;

namespace CallMePhonyApp.Views;

public partial class SiteList : ContentPage
{
	private readonly SiteListViewModel _viewModel;

	public SiteList(SiteListViewModel viewModel)
	{
		BindingContext = _viewModel = viewModel;
		InitializeComponent();
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
}