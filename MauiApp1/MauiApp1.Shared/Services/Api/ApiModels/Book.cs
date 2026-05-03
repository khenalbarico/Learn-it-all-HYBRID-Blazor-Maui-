using System.ComponentModel.DataAnnotations;

namespace MauiApp1.Shared.Services.Api.ApiModels;

public class Book
{
    [Required] public string         Uid         { get; set; } = "";
               public string         Title       { get; set; } = "";
               public BookCategories Category    { get; set; }
               public BookMainTopics MainTopic   { get; set; }
               public BookSubTopics  SubTopic    { get; set; }
               public string         Description { get; set; } = "";
               public decimal        Price       { get; set; }
}
