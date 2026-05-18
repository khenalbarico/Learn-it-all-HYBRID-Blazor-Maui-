using MauiApp1.Shared.Services.Api.ApiModels.Books;
using MauiApp1.Shared.Services.Api.ApiModels.Users;

namespace MauiApp1.Shared.State;

public class AppState
{
    private readonly Dictionary<string, IEnumerable<Book>> _bookCache        = new(StringComparer.OrdinalIgnoreCase);
    private readonly HashSet<string>                      _loadingCategories = new(StringComparer.OrdinalIgnoreCase);

    public IEnumerable<Book> IntroBooks   { get; private set; } = [];
    public bool              IsLoading    { get; private set; } = false;
    public string?           Error        { get; private set; }
    public Book?             ActiveBook   { get; private set; }
    public AppUser?          CurrentUser  { get; private set; }
    public Book?             PendingBook  { get; set; }
    public GetSignInResult?  SignInResult { get; set; }
    public string?           IdToken      { get; private set; }

    public event Action?     OnChange;

    public bool HasCategoryLoaded(string category)
        => _bookCache.ContainsKey(category);

    public bool IsCategoryLoading(string category)
        => _loadingCategories.Contains(category);

    public IEnumerable<Book> GetBooks(string category)
        => _bookCache.TryGetValue(category, out var books) ? books : [];

    public void SetCategoryLoading(string category)
    {
        _loadingCategories.Add(category);
        IsLoading = true;
        Error     = null;
        NotifyChanged();
    }

    public void SetBooks(string category, IEnumerable<Book> books)
    {
        _bookCache[category] = books;
        _loadingCategories.Remove(category);
        IsLoading = false;
        Error     = null;
        NotifyChanged();
    }

    public void SetIntroBooks(IEnumerable<Book> books)
    {
        IntroBooks = books;
        NotifyChanged();
    }

    public void SetError(string message)
    {
        Error     = message;
        IsLoading = false;
        _loadingCategories.Clear();
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

    public void SetSignInResult(GetSignInResult result)
    {
        SignInResult = result;
        IdToken      = result.IdToken;
        NotifyChanged();
    }

    public void ClearUser()
    {
        CurrentUser  = null;
        SignInResult = null;
        IdToken      = null;
        _bookCache.Clear();
        _loadingCategories.Clear();
        NotifyChanged();
    }

    private void NotifyChanged() => OnChange?.Invoke();
}
