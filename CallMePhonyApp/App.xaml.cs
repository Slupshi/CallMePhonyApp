using CallMePhonyApp.ViewModels;

namespace CallMePhonyApp;

public partial class App : Application
{
    private readonly MainViewModel _mainViewModel;

    public App(AppNavigationPage appNavigationPage)
    {
        InitializeComponent();

        MainPage = appNavigationPage;
    }
}
