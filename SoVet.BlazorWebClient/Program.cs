using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SoVet.BlazorWebClient;
using SoVet.BlazorWebClient.Services;
using SoVet.BlazorWebClient.Services.Impl;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var connectionString = builder.Configuration.GetConnectionString("ApiConnection");
if (connectionString is null)
    throw new InvalidOperationException("APIBaseAddress missing from appsettings file.");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(connectionString) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

await builder.Build().RunAsync();