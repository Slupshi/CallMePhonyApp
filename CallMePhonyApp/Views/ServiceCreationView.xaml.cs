using CallMePhonyApp.ViewModels;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Views;

public partial class ServiceCreationView : ContentPage
{
	private readonly ServiceListViewModel _viewModel;

	public ServiceCreationView(ServiceListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await _viewModel.AddService(new Service() { Name = ServiceNameEntry.Text });
	}
}