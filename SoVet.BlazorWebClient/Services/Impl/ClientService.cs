using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

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

    public async Task<Client?> GetClient(string email)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Client>($"Client/client?clientEmail={email}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<BaseResult?> UpdateClient(Client client, string oldEmail, string? newPassword)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"Client/update?oldEmail={oldEmail}&password={newPassword}", client);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }
}