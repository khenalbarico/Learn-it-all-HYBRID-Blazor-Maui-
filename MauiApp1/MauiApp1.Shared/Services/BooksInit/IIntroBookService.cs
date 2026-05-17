using MauiApp1.Shared.Services.Api.ApiModels.Books;

namespace MauiApp1.Shared.Services.BooksInit;

public interface IIntroBookService
{
    Task<IEnumerable<Book>> LoadAsync();
}
