using MauiApp1.Shared.Services.Api.ApiClients;
using MauiApp1.Shared.State;

namespace MauiApp1.Shared.Services;

public class AuthTokenProvider(AppState _state) : IAuthTokenProvider
{
    public Task<string?> GetCurrentTokenAsync()
        => Task.FromResult(_state.IdToken);
}