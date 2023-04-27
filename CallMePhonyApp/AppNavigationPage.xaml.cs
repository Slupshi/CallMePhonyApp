using CallMePhonyApp.ViewModels;
using CallMePhonyApp.Views;

namespace CallMePhonyApp;

public partial class AppNavigationPage : TabbedPage
{
    public AppNavigationPage(MainViewModel mainViewModel, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        BindingContext = mainViewModel;
        // Get the page added as a Scoped service unto the dependency injection
        var userListPage = new NavigationPage(serviceProvider.GetService<UserList>());
        userListPage.Title = "Annuaire";
        Children.Add(userListPage);
        var siteListPage = new NavigationPage(serviceProvider.GetService<SiteList>());
        siteListPage.Title = "Liste des sites";
        Children.Add(siteListPage);
        var serviceListPage = new NavigationPage(serviceProvider.GetService<ServiceList>());
        serviceListPage.Title = "Liste des services";
        Children.Add(serviceListPage);
        var loginView = new NavigationPage(serviceProvider.GetService<LoginView>());
        loginView.Title = "Portails administratif";
        Children.Add(loginView);
    }
}