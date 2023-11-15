using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SoVet.BlazorWebClient;
using SoVet.BlazorWebClient.Services;
using SoVet.BlazorWebClient.Services.Impl;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var connectionString = builder.Configuration.GetConnectionString("ApiConnection");
if (connectionString is null)
    throw new InvalidOperationException("APIBaseAddress missing from appsettings file.");

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IClinicService, ClinicService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IAnimalTypeService, AnimalTypeService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(connectionString) });
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();


await builder.Build().RunAsync();