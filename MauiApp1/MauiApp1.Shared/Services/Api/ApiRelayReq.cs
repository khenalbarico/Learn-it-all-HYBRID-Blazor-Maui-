namespace MauiApp1.Shared.Services.Api;

public class ApiRelayReq
{
    public string ClassName  { get; set; } = string.Empty;
    public string MethodName { get; set; } = string.Empty;
    public object? Payload   { get; set; }
}
