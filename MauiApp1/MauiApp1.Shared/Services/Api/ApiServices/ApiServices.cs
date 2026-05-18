using MauiApp1.Shared.Services.Api.ApiClients;
using MauiApp1.Shared.Services.Api.ApiModels.Books;
using MauiApp1.Shared.Services.Api.ApiModels.Users;

namespace MauiApp1.Shared.Services.Api.ApiServices;

public class ApiServices(IApiClient _apiClient) : IApiServices
{
    #region Repository

    public async Task<AppUser?> TryGetAppUser(string uid)
    {
        try
        {
            return await _apiClient.SubmitAsync<AppUser>("IAppRepository", "TryGetAppUser", new { uid });
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

    public async Task SaveAppUser(AppUser user)
    {
        try
        {
            await _apiClient.SubmitAsync("IAppRepository", "SaveAppUser", new { user });
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync(string category)
    {
        try
        {
            return await _apiClient.SubmitAsync<IEnumerable<Book>>("IAppRepository", "GetAllBooksAsync", new { category });
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Book?> GetBookAsync(string category, string bookUid)
    {
        try
        {
            return await _apiClient.SubmitAsync<Book>("IAppRepository", "GetBookAsync", new { category, bookUid });
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

    public async Task AddToLibraryAsync(LibraryEntry entry)
    {
        try
        {
            await _apiClient.SubmitAsync("IAppRepository", "AddToLibraryAsync", new { entry });
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> UserOwnsBookAsync(string bookUid)
    {
        try
        {
            return await _apiClient.SubmitAsync<bool>("IAppRepository", "UserOwnsBookAsync", new { bookUid });
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
            await _apiClient.SubmitAsync("IAppAuth", "SignUpAsync", new { email, password });
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
            return await _apiClient.SubmitAsync<GetSignInResult>("IAppAuth", "SignInAsync", new { email, password });
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion
}
