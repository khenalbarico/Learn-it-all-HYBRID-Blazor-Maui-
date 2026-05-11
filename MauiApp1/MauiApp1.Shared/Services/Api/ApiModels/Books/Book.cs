using System.ComponentModel.DataAnnotations;

namespace MauiApp1.Shared.Services.Api.ApiModels.Books;

public class Book
{
    [Required] public string  Uid        { get; set; } = "";
               public string  ImageUrl   { get; set; } = "";
               public string  Title      { get; set; } = "";
               public string  Desription { get; set; } = "";
               public decimal Price      { get; set; }
}

