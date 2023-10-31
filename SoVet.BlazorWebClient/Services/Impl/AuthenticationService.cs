using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services.Impl;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AuthenticationService> _logger;
    private readonly ITokenService _tokenService;

    public AuthenticationService(HttpClient httpClient, ILogger<AuthenticationService> logger, ITokenService tokenService)
    {
        _httpClient = httpClient;
        _logger = logger;
        _tokenService = tokenService;
    }

    public async Task<BaseResult> Register(UserRegistration userRegistration)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("register", userRegistration);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();

            return result ?? new BaseResult{IsSuccess = false, Message = "Ошибка при регистрации клиента"};
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return new BaseResult { IsSuccess = false, Message = "Ошибка при регистрации клиента" };
        }
    }
}