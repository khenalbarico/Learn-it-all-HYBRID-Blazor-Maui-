namespace MauiApp1.Shared.Services.Api;

public class ApiUrlGetter : IApiUrlGetter
{
    public string GetApiUrl(string env)
    {
        env = env.Trim().ToLowerInvariant();

        return env switch
        {
            "localhost" => "http://localhost:7041/",
            _           => "https://sample.azurewebsites.net/"
        };
    }
}