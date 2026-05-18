namespace MauiApp1.Shared.Services.Api.ApiModels.Books;

public class LibraryEntry
{
    public string  BookUid         { get; set; } = "";
    public string  OrderId         { get; set; } = "";
    public decimal PriceAtPurchase { get; set; }
    public string  PurchasedAt     { get; set; } = "";
}