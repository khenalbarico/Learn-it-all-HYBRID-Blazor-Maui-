namespace MauiApp1.Shared.Services.Api.ApiModels;

public class GetAllBooks
{
    public IEnumerable<Book> Books       { get; set; } = [];
}
