using CallMePhonyApp.ViewModels;

namespace CallMePhonyApp.Views;

public partial class LoginView : ContentPage
{
	private readonly LoginViewModel _viewModel;

	public LoginView(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}

	private void Login_Button_Clicked(object sender, EventArgs e)
	{
		_viewModel.LogUser(EmailEntry.Text, PasswordEntry.Text);
	}
}