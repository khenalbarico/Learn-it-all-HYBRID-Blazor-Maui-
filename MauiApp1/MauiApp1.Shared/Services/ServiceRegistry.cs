using MauiApp1.Shared.Services.Api.ApiClients;
using MauiApp1.Shared.Services.Api.ApiServices;
using MauiApp1.Shared.State;
using Microsoft.Extensions.DependencyInjection;

namespace MauiApp1.Shared.Services;

public static class ServiceRegistry
{
    public static void RegisterServices(this IServiceCollection svc, string env)
    {
        svc.AddSingleton<AppState>();
        svc.AddSingleton<IApiClient, ApiClient>();
        svc.AddSingleton<IApiServices, ApiServices>();
        svc.AddCustomHttpClient(env);
    }
}
