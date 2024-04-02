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

    public async Task<BaseResult> DeleteFacilityInAppointment(int appointmentFacilityId)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"Facility/delete-in-appointment", appointmentFacilityId);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            return result ?? new BaseResult {IsSuccess = false, Message = "Произошла ошибка при обновлении"};
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BaseResult {IsSuccess = false, Message  = "Произошла ошибка при обновлении"};
        }
    }

    public async Task<List<Facility>?> GetFacilities()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Facility>>("Facility");
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }
    
    public async Task<List<FacilityCategory>?> GetFacilityCategories()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<FacilityCategory>>("Facility/facility-categories");
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<BaseResult> UpdateFacility(Facility facility)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync("facility",facility);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            return result ?? new BaseResult {IsSuccess = false, Message = "Произошла ошибка при сохранении"};
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BaseResult{IsSuccess = false, Message = "Произошла ошибка при сохранении"};
        }
    }
}