using System.ComponentModel.DataAnnotations;

namespace MauiApp1.Shared.Services.Api.ApiModels;

public class Book
{
    [Required] public string         Uid         { get; set; } = "";
               public string         Title       { get; set; } = "";
               public string         Category    { get; set; } = "";
               public string         MainTopic   { get; set; } = "";
               public string         SubTopic    { get; set; } = "";
               public string         Description { get; set; } = "";
               public decimal        Price       { get; set; }
}
