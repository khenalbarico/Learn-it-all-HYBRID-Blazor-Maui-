using System.ComponentModel.DataAnnotations;

namespace MauiApp1.Shared.Services.Api.ApiModels;

public class User
{
    [Required] public string Uid         { get; set; } = "";
               public string BearerToken { get; set; } = "";
}
