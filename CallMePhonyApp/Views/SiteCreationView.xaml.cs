using CallMePhonyApp.ViewModels;
using CallMePhonyEntities.Enums;

namespace CallMePhonyApp.Views;

public partial class SiteCreationView : ContentPage
{
	private readonly SiteListViewModel _viewModel;

	public SiteCreationView(SiteListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await _viewModel.AddService(new CallMePhonyEntities.Models.Site()
		{
			Name = SiteNameEntry.Text,
			SiteType = SiteTypePicker.SelectedItem.ToString() == "Administration" ? SiteType.Administration : SiteType.Production,
		});
	}
}