using LearnItAllApi.Infrastructure1.FirebaseServices.Authentication;
using MauiApp1.Shared.Services.Api.ApiClients;
using MauiApp1.Shared.Services.Api.ApiServices;
using MauiApp1.Shared.Services.Authentication;
using MauiApp1.Shared.Services.BooksInit;
using MauiApp1.Shared.State;
using Microsoft.Extensions.DependencyInjection;

namespace MauiApp1.Shared.Services;

public static class ServiceRegistry
{
    public static void RegisterServices(this IServiceCollection svc, string env)
    {
        svc.AddSingleton<AppState>();
        svc.AddSingleton<IFirebaseCfg, FirebaseCfg>();
        svc.AddSingleton<IAuthTokenProvider, AuthTokenProvider>();
        svc.AddSingleton<IApiClient, ApiClient>();
        svc.AddSingleton<IApiServices, ApiServices>();
        svc.AddSingleton<IAppAuth, AppAuth>();
        svc.AddSingleton<IIntroBookService, IntroBookService>();
        svc.AddCustomHttpClient(env);
    }
}