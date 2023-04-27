using CallMePhonyApp.ViewModels;

namespace CallMePhonyApp;

public partial class App : Application
{
    private readonly MainViewModel _mainViewModel;

    public App(MainViewModel mainViewModel)
    {
        InitializeComponent();

        MainPage = new AppNavigationPage();
        BindingContext = _mainViewModel = mainViewModel;
    }
}
