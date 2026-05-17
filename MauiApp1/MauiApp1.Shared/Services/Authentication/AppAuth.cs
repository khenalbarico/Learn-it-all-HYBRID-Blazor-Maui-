using MauiApp1.Shared.Services.Authentication;
using System.Text;
using System.Text.Json;

namespace LearnItAllApi.Infrastructure1.FirebaseServices.Authentication;

public class AppAuth(IFirebaseCfg _cfg, HttpClient _httpClient) : IAppAuth
{
    public async Task<string> SignInAsync(string email, string password)
    {
        var authClient = _cfg.CreateAuthClient();
        var res        = await authClient.SignInWithEmailAndPasswordAsync(email, password);
        if (!res.User.Info.IsEmailVerified)
        {
            authClient.SignOut();
            throw new UnauthorizedAccessException("Email not yet verified.");
        }
        return await res.User.GetIdTokenAsync();
    }

    public async Task SignUpAsync(string email, string password)
    {
        var authClient = _cfg.CreateAuthClient();
        var res        = await authClient.CreateUserWithEmailAndPasswordAsync(email, password);
        var token      = await res.User.GetIdTokenAsync();
        await SendEmailVerificationAsync(token);
        authClient.SignOut();
    }

    public async Task SignOutAsync()
        => _cfg.CreateAuthClient().SignOut(); 

    async Task SendEmailVerificationAsync(string idToken)
    {
              var url         = $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={_cfg.ApiKey}";
              var requestBody = new { requestType = "VERIFY_EMAIL", idToken };
              var json        = JsonSerializer.Serialize(requestBody);
        using var content     = new StringContent(json, Encoding.UTF8, "application/json");
        using var res         = await _httpClient.PostAsync(url, content);
              var resTxt      = await res.Content.ReadAsStringAsync();

        if (!res.IsSuccessStatusCode)
            throw new InvalidOperationException($"Failed to send verification email: {resTxt}");
    }
}