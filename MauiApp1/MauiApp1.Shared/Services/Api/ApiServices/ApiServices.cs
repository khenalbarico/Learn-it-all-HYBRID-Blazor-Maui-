using MauiApp1.Shared.Services.Api.ApiClients;
using MauiApp1.Shared.Services.Api.ApiModels.Books;
using MauiApp1.Shared.Services.Api.ApiModels.Users;

namespace MauiApp1.Shared.Services.Api.ApiServices;

public class ApiServices(IApiClient _apiClient) : IApiServices
{
    public async Task<AppUser?> TryGetAppUser(string idToken, string uid)
    {
        try
        {
            var resp = await _apiClient.SubmitAsync<AppUser>("IAppRepository", "TryGetAppUser", new { idToken, uid });

            return resp;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        try
        {
            var resp = await _apiClient.GetAsync<IEnumerable<Book>>("IAppRepository", "GetAllBooksAsync");

            return resp;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
