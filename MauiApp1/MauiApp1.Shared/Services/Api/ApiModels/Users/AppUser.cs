using System.ComponentModel.DataAnnotations;

namespace MauiApp1.Shared.Services.Api.ApiModels.Users;

public class AppUser
{
    [Required] public string              Uid          { get; set; } = "";
               public string              Email        { get; set; } = "";
               public string              DisplayName  { get; set; } = "";
               public SubscriptionType    Subscription { get; set; } = SubscriptionType.Free;
               public IEnumerable<string> Library      { get; set; } = [];
}
