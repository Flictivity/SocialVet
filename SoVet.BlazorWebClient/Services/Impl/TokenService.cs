using Blazored.LocalStorage;

namespace SoVet.BlazorWebClient.Services.Impl;

public sealed class TokenService : ITokenService
{
    private readonly ILocalStorageService _localStorageService;

    public TokenService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    
    public async Task<string> GetToken()
    {
        return await _localStorageService.GetItemAsync<string>("token");
    }

    public async Task RemoveToken()
    {
        await _localStorageService.RemoveItemAsync("token");
    }

    public async Task SetToken(string token)
    {
        await _localStorageService.SetItemAsync("token", token);
    }
}