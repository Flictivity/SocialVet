using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models;

namespace SoVet.BlazorWebClient.Services.Impl;

public sealed class ClientService : IClientService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ClientService> _logger;

    public ClientService(HttpClient httpClient, ILogger<ClientService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<Client>?> GetClients()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Client>>("Client");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }
}