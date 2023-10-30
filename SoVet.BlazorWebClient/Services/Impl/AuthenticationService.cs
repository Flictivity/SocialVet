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

    public async Task<UserRegistrationResult> Register(UserRegistration userRegistration)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("register", userRegistration);
            var result = await response.Content.ReadFromJsonAsync<UserRegistrationResult>();
            if (result is null)
            {
                return new UserRegistrationResult { IsSuccess = false };
            }
            if (result.Token is null)
            {
                return new UserRegistrationResult { IsSuccess = false };
            }

            await _tokenService.SetToken(result.Token);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return new UserRegistrationResult
            {
                IsSuccess = false
            };
        }
    }
}