using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services.Impl;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AuthenticationService> _logger;
    private readonly ITokenService _tokenService;
    private readonly CustomAuthenticationStateProvider _myAuthenticationStateProvider;

    public AuthenticationService(HttpClient httpClient, ILogger<AuthenticationService> logger, ITokenService tokenService, CustomAuthenticationStateProvider myAuthenticationStateProvider)
    {
        _httpClient = httpClient;
        _logger = logger;
        _tokenService = tokenService;
        _myAuthenticationStateProvider = myAuthenticationStateProvider;
    }

    public async Task<BaseResult> Register(UserRegistration userRegistration)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("register", userRegistration);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            
            return result ?? new BaseResult { IsSuccess = false, Message = "Ошибка при регистрации клиента" };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return new BaseResult { IsSuccess = false, Message = "Ошибка при регистрации клиента" };
        }
    }

    public async Task<AuthorizationResult> Login(UserLogin userLogin)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("login", userLogin);
            var result = await response.Content.ReadFromJsonAsync<AuthorizationResult>();

            if (result is null)
                return new AuthorizationResult { IsSuccess = false, Message = "Ошибка при авторизации клиента" };
            
            if (result.Token is null)
                return new AuthorizationResult { IsSuccess = false, Message = result.Message };

            await _tokenService.SetToken(result.Token);
            
            _myAuthenticationStateProvider.StateChanged();
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return new AuthorizationResult { IsSuccess = false, Message = "Ошибка при авторизации клиента" };
        }
    }
}