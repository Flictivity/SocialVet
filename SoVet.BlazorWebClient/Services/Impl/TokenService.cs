using Blazored.LocalStorage;
using SoVet.BlazorWebClient.Models;

namespace SoVet.BlazorWebClient.Services.Impl;

public sealed class TokenService : ITokenService
{
    private readonly ILocalStorageService _localStorageService;

    public TokenService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    
    public async Task<TokenDTO?> GetToken()
    {
        return await _localStorageService.GetItemAsync<TokenDTO>("token");
    }

    public async Task RemoveToken()
    {
        await _localStorageService.RemoveItemAsync("token");
    }

    public async Task SetToken(TokenDTO token)
    {
        await _localStorageService.SetItemAsync("token", token);
    }
}