namespace MauiApp1.Shared.Services.Api.ApiClients;

public interface IApiClient
{
    Task<TRes> GetAsync<TRes>(string className, string methodName);
    Task<TRes> SubmitAsync<TRes>(string className, string methodName, object? payload);
    Task SubmitAsync(string className, string methodName, object? payload);
}
