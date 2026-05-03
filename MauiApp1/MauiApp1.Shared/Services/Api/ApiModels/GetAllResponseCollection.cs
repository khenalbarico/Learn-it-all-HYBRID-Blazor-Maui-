namespace MauiApp1.Shared.Services.Api.ApiModels;

public class GetAllResponseCollection
{
    public IEnumerable<Book> Books       { get; set; } = [];
    public User              CurrentUser { get; set; } = new User();
}
