using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models;

namespace SoVet.BlazorWebClient.Services.Impl;

public sealed class AnimalTypeService : IAnimalTypeService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AnimalTypeService> _logger;

    public AnimalTypeService(HttpClient httpClient, ILogger<AnimalTypeService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<AnimalType>?> GetAnimalTypes()
    {
        try
        {
            var res = await _httpClient.GetFromJsonAsync<List<AnimalType>>("AnimalType");
            return res;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }
}