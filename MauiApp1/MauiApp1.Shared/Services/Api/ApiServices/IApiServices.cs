using MauiApp1.Shared.Services.Api.ApiModels.Books;
using MauiApp1.Shared.Services.Api.ApiModels.Users;

namespace MauiApp1.Shared.Services.Api.ApiServices;

public interface IApiServices
{
    Task<AppUser?> TryGetAppUser(string uid);
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task SignUpAsync(string email, string password);
    Task<GetSignInResult> SignInAsync(string email, string password);
    Task SaveAppUser(AppUser user);
}
