using MauiApp1.Shared.Services.Api.ApiModels.Books;
using MauiApp1.Shared.Services.Api.ApiModels.Users;

namespace MauiApp1.Shared.Services.Api.ApiServices;

public interface IApiServices
{
    Task<AppUser?> TryGetAppUser(string uid);
    Task SaveAppUser(AppUser user);
    Task<IEnumerable<Book>> GetAllBooksAsync(string category);
    Task<Book?> GetBookAsync(string category, string bookUid);
    Task AddToLibraryAsync(LibraryEntry entry);
    Task<bool> UserOwnsBookAsync(string bookUid);
    Task SignUpAsync(string email, string password);
    Task<GetSignInResult> SignInAsync(string email, string password);
}
