namespace MauiApp1.Shared.Services.Api.ApiClients;

public class ApiRelayReq
{
    public string ClassName  { get; set; } = "";
    public string MethodName { get; set; } = "";
    public object? Payload   { get; set; }
}
