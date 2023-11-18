using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services.Impl;

public class FacilityService : IFacilityService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<FacilityService> _logger;

    public FacilityService(HttpClient httpClient, ILogger<FacilityService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<BaseResult> SaveFacilityInAppointment(AppointmentFacility appointmentFacility)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"Facility/save-in-appointment",appointmentFacility);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            return result ?? new BaseResult {IsSuccess = false, Message = "Произошла ошибка при обновлении"};
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BaseResult {IsSuccess = false, Message  = "Произошла ошибка при обновлении"};
        }
    }
}