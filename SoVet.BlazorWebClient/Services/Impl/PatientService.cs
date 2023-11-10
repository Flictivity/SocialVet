using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models;

namespace SoVet.BlazorWebClient.Services.Impl;

public sealed class PatientService : IPatientService
{
    private readonly HttpClient _httpClient;

    public PatientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Patient>?> GetPatients(int? clientId)
    {
        return await _httpClient.GetFromJsonAsync<List<Patient>>($"Patient/patients?clientId={clientId}");
    }
}