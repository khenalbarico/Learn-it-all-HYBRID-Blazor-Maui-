using System.Net.Http.Json;

namespace MauiApp1.Shared.Services.Api.ApiClients;

public class ApiClient (IHttpClientFactory _httpClientFactory) : IApiClient
{
    public async Task<TRes> GetAsync<TRes>(string className, string methodName)
    {
        var req = new ApiRelayReq
        {
            ClassName  = className,
            MethodName = methodName,
            Payload    = null
        };

              var http     = _httpClientFactory.CreateClient("ApiRelayer");
        using var response = await http.PostAsJsonAsync("api/relay", req);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed: {(int)response.StatusCode} {response.ReasonPhrase}. {body}");
        }

        var result = await response.Content.ReadFromJsonAsync<TRes>();

        return result ?? throw new InvalidOperationException("The API returned no content.");
    }

    public async Task<TRes> SubmitAsync<TRes>(string className, string methodName, object? payload)
    {
        var req = new ApiRelayReq
        {
            ClassName  = className,
            MethodName = methodName,
            Payload    = payload
        };

              var http     = _httpClientFactory.CreateClient("ApiRelayer");
        using var response = await http.PostAsJsonAsync("api/relay", req);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed: {(int)response.StatusCode} {response.ReasonPhrase}. {body}");
        }

        var result = await response.Content.ReadFromJsonAsync<TRes>();

        return result ?? throw new InvalidOperationException("The API returned no content.");
    }

    public async Task SubmitAsync(string className, string methodName, object? payload)
    {
        var req = new ApiRelayReq
        {
            ClassName  = className,
            MethodName = methodName,
            Payload    = payload
        };

              var http = _httpClientFactory.CreateClient("ApiRelayer");
        using var resp = await http.PostAsJsonAsync("api/relay", req);

        if (!resp.IsSuccessStatusCode)
        {
            var body = await resp.Content.ReadAsStringAsync();

            throw new HttpRequestException($"Request failed: {(int)resp.StatusCode} {resp.ReasonPhrase}. {body}");
        }
    }
}
