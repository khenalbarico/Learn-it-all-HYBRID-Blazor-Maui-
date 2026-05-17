using MauiApp1.Shared.Services.Api.ApiModels.Books;
using System.Text.Json;

namespace MauiApp1.Shared.Services.BooksInit;

public class IntroBookService : IIntroBookService
{
    static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public async Task<IEnumerable<Book>> LoadAsync()
    {
        var assembly = typeof(IntroBookService).Assembly;

        var resourceName = assembly.GetManifestResourceNames()
            .FirstOrDefault(n => n.EndsWith("introductory_books.json"))
            ?? throw new InvalidOperationException("introductory_books.json not found. Make sure it is marked as EmbeddedResource in the shared project.");

        await using var stream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException("Could not open introductory_books.json stream.");

        return await JsonSerializer.DeserializeAsync<IEnumerable<Book>>(stream, JsonOptions)
            ?? [];
    }
}