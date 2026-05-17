namespace MauiApp1.Shared.Services.Authentication;

public interface IAppAuth
{
    Task<string> SignInAsync(
     string email,
     string password);
    Task SignUpAsync(
        string email,
        string password);
    Task SignOutAsync();
}
