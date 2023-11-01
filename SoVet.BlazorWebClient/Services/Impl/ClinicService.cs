using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services.Impl;

public sealed class ClinicService : IClinicService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AuthenticationService> _logger;

    public ClinicService(HttpClient httpClient, ILogger<AuthenticationService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Clinic?> GetClinicInfoAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<Clinic>("clinic");
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public Task<BaseResult> UpdateClinicAsync(Clinic clinic)
    {
        throw new NotImplementedException();
    }
}