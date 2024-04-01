using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Models.RegistrationModels;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services.Impl;

public sealed class RegistrationService : IRegistrationService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AuthenticationService> _logger;

    public RegistrationService(HttpClient httpClient, ILogger<AuthenticationService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<TimeSpan>?> GetAvailableRegistrationTimes(GetAvailableRegistrationsRequest request)
    {
        try
        {
            var result =
                await _httpClient.GetFromJsonAsync<List<TimeSpan>>(
                    $"registration/available-times?employeeId={request.EmployeeId}&date={request.RegistrationDate.ToString("yyyy-MM-dd")}");
            return result;
        }
        catch
        {
            return new List<TimeSpan>();
        }
    }

    public async Task<BaseResult> CreateRegistration(RegistrationCreateRequest request)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("Registration/create", request);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            return result ?? new BaseResult { IsSuccess = false, Message = "Ошибка при создании новой записи" };
        }
        catch(Exception ex)
        {
            _logger.LogError("Error:{1}", ex.Message);
            return new BaseResult { IsSuccess = false, Message = "Ошибка при создании новой записи" };
        }
    }

    public async Task<List<Registration>?> GetRegistrations(int? employeeId, int? clientId = null)
    {
        try
        {
            var result =
                await _httpClient.GetFromJsonAsync<List<Registration>>(
                    $"registration?employeeId={employeeId}&clientId={clientId}");
            return result;
        }
        catch
        {
            return new List<Registration>();
        }
    }

    public async Task<BaseResult> DeleteRegistration(int registrationId)
    {
        try
        {
            var result = await _httpClient.DeleteFromJsonAsync<BaseResult>($"registration?registrationId={registrationId}");
            return result ?? new BaseResult { IsSuccess = false, Message = "Ошибка при отмене записи. Вроверьте соединение с сервером" };
        }
        catch(Exception ex)
        {
            _logger.LogError("Error:{1}", ex.Message);
            return new BaseResult { IsSuccess = false, Message = "Ошибка при отмене записи. Вроверьте соединение с сервером" };
        }
    }
}