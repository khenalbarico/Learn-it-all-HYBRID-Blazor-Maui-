using MauiApp1.Shared.Services.Api.ApiClients;
using MauiApp1.Shared.Services.Api.ApiModels.Books;
using MauiApp1.Shared.Services.Api.ApiModels.Users;

namespace MauiApp1.Shared.Services.Api.ApiServices;

public class ApiServices(IApiClient _apiClient) : IApiServices
{
    #region Repository
    public async Task<AppUser?> TryGetAppUser(string idToken, string uid)
    {
        try
        {
            var resp = await _apiClient.SubmitAsync<AppUser>("IAppRepository", "TryGetAppUser", new { idToken, uid });
            return resp;
        }
        catch (Exception ex) when (ex.Message.Contains("no content", StringComparison.OrdinalIgnoreCase)
                                 || ex.Message.Contains("null", StringComparison.OrdinalIgnoreCase)
                                 || ex.Message.Contains("204", StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task SaveAppUser(string idToken, AppUser user)
    {
        try
        {
            await _apiClient.SubmitAsync("IAppRepository", "SaveAppUser", new { idToken, user });
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
    #endregion

    #region Authentication
    public async Task SignUpAsync(string email, string password)
    {
        try
        {
            await _apiClient.SubmitAsync("IAppAuth", "SignUpAsync", new {email, password});
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<GetSignInResult> SignInAsync(string email, string password)
    {
        try
        {
            var resp = await _apiClient.SubmitAsync<GetSignInResult>("IAppAuth", "SignInAsync", new { email, password });

            return resp;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion
}
