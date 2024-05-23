using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services.Impl;

public sealed class DiagnosisService : IDiagnosisService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<DiagnosisService> _logger;

    public DiagnosisService(HttpClient httpClient, ILogger<DiagnosisService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<BaseResult> SaveDiagnosis(Diagnosis diagnosis)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"Diagnosis/save",diagnosis);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            return result ?? new BaseResult {IsSuccess = false, Message = "Произошла ошибка при обновлении"};
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BaseResult {IsSuccess = false, Message  = "Произошла ошибка при обновлении"};
        }
    }

    public async Task<BaseResult> SaveDiagnosisInAppointment(AppointmentDiagnoses appointmentDiagnoses)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"Diagnosis/save-in-appointment",appointmentDiagnoses);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            return result ?? new BaseResult {IsSuccess = false, Message = "Произошла ошибка при обновлении"};
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BaseResult {IsSuccess = false, Message  = "Произошла ошибка при обновлении"};
        }
    }

    public async Task<BaseResult> DeleteDiagnosisInAppointment(int appointmentDiagnosisId)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"Diagnosis/delete-in-appointment", appointmentDiagnosisId);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            return result ?? new BaseResult {IsSuccess = false, Message = "Произошла ошибка при обновлении"};
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BaseResult {IsSuccess = false, Message  = "Произошла ошибка при обновлении"};
        }
    }

    public async Task<BaseResult> DeleteDiagnosis( int diagnosisId)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"Diagnosis/delete", diagnosisId);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            return result ?? new BaseResult {IsSuccess = false, Message = "Произошла ошибка при обновлении"};
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BaseResult {IsSuccess = false, Message  = "Произошла ошибка при обновлении"};
        }
    }
    
    public async Task<List<Diagnosis>?> GetDiagnoses()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Diagnosis>>("Diagnosis");
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }
}