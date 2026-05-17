using Firebase.Auth;
using Firebase.Auth.Providers;

namespace MauiApp1.Shared.Services.Authentication;

public static class FirebaseClientFactory
{
    public static FirebaseAuthClient CreateAuthClient(this IFirebaseCfg cfg)
    {
        return new FirebaseAuthClient(new FirebaseAuthConfig
        {
            ApiKey     = cfg.ApiKey,
            AuthDomain = cfg.AuthDomain,
            Providers  = [new EmailProvider()]
        });
    }
}