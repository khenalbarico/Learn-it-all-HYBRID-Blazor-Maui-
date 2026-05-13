using MauiApp1.Shared.Services.Api.ApiModels.Books;
using MauiApp1.Shared.Services.Api.ApiModels.Users;

namespace MauiApp1.Shared.State;

public class AppState
{
    public IEnumerable<Book> Books        { get; private set; } = [];
    public bool              IsLoading    { get; private set; } = false;
    public bool              HasLoaded    { get; private set; } = false;
    public string?           Error        { get; private set; }
    public Book?             ActiveBook   { get; private set; }
    public AppUser?          CurrentUser  { get; private set; }
    public Book?             PendingBook  { get; set; }
    public GetSignInResult?  SignInResult { get; set; }

    public event Action?     OnChange;

    public void SetLoading()
    {
        IsLoading = true;
        Error     = null;
        NotifyChanged();
    }

    public void SetBooks(IEnumerable<Book> books)
    {
        Books     = books;
        IsLoading = false;
        HasLoaded = true;
        Error     = null;
        NotifyChanged();
    }

    public void SetError(string message)
    {
        Error     = message;
        IsLoading = false;
        NotifyChanged();
    }

    public void SelectBook(Book book)
    {
        ActiveBook = book;
        NotifyChanged();
    }

    public void ClearActiveBook()
    {
        ActiveBook = null;
        NotifyChanged();
    }

    public void SetUser(AppUser user)
    {
        CurrentUser = user;
        NotifyChanged();
    }

    public void ClearUser()
    {
        CurrentUser  = null;
        SignInResult = null;
        NotifyChanged();
    }

    private void NotifyChanged() => OnChange?.Invoke();
}