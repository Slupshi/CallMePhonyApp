using CallMePhonyApp.Data;
using CallMePhonyApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace CallMePhonyApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Registering services for Dependency Injection
        builder.Services.AddScoped<IApiService, ApiService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<ISiteService, SiteService>();
        builder.Services.AddScoped<IServiceService, ServiceService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        // Same with ViewModels
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddScoped<UserListViewModel>();
        builder.Services.AddScoped<SiteListViewModel>();
        builder.Services.AddScoped<ServiceListViewModel>();
        builder.Services.AddScoped<LoginViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
