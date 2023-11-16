using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services.Impl;

public sealed class PatientService : IPatientService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<PatientService> _logger;

    public PatientService(HttpClient httpClient, ILogger<PatientService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<Patient>?> GetPatients(int? clientId)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Patient>>($"Patient/patients?clientId={clientId}");
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<BaseResult> UpdatePatient(Patient patient)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync("Patient/update", patient);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            return result ?? new BaseResult {IsSuccess = false, Message = "Произошла ошибка при обновлении"};
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BaseResult {IsSuccess = false, Message = "Произошла ошибка при обновлении"};
        }
    }

    public async Task<BaseResult> CreatePatient(Patient patient)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("Patient/create", patient);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            return result ?? new BaseResult {IsSuccess = false, Message = "Произошла ошибка при добавлении сотрудника"};
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BaseResult {IsSuccess = false, Message = ex.Message};
        }
    }
}