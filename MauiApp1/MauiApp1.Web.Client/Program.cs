using MauiApp1.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var env = builder.Configuration["ASPNETCORE_ENVIRONMENT"] ?? "Production";

builder.Services.RegisterServices(env);

await builder.Build().RunAsync();
