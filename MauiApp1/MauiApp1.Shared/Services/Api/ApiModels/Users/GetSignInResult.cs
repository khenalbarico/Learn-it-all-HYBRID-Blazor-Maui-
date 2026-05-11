namespace MauiApp1.Shared.Services.Api.ApiModels.Users;

public record GetSignInResult(
    string UserId,
    string Email,
    string DisplayName,
    string IdToken);
