namespace MauiApp1.Shared.Services.Api.ApiClients;

public interface IAuthTokenProvider
{
    Task<string?> GetCurrentTokenAsync();
}