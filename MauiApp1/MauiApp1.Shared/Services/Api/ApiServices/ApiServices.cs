using MauiApp1.Shared.Services.Api.ApiClients;

namespace MauiApp1.Shared.Services.Api.ApiServices;

public class ApiServices (IApiClient _apiClient) : IApiServices
{
    public async Task GetAllAsync()
    {
    }
}
