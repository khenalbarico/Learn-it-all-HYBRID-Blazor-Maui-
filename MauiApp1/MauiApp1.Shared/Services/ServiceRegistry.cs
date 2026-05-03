using MauiApp1.Shared.Services.Api.ApiClients;
using Microsoft.Extensions.DependencyInjection;

namespace MauiApp1.Shared.Services;

public static class ServiceRegistry
{
    public static void RegisterServices(this IServiceCollection svc, string env)
    {
        svc.AddCustomHttpClient(env);
    }
}
