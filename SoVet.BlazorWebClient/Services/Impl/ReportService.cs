using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models;

namespace SoVet.BlazorWebClient.Services.Impl;

public sealed class ReportService : IReportService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<FacilityService> _logger;

    public ReportService(HttpClient httpClient, ILogger<FacilityService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<DataItem[]> AppointmentsStatusesInfo()
    {
        try
        {
            var result = await _httpClient.GetFromJsonAsync<DataItem[]>("Report/appointments-statuses-info");
            return result ?? Array.Empty<DataItem>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Array.Empty<DataItem>();
        }
    }

    public async Task<DataItem[]> AppointmentsInYear(int year)
    {
        try
        {
            var result = await _httpClient.GetFromJsonAsync<DataItem[]>($"Report/appointments-in-year?year={year}");
            return result ?? Array.Empty<DataItem>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Array.Empty<DataItem>();
        }
    }

    public async Task<int> AppointmentsInMonthCount()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<int>("Report/appointments-in-month-count");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return 0;
        }
    }

    public async Task<List<FacilityReport>> FacilityReport(DateTime start, DateTime end)
    {
        try
        {
            var result = await _httpClient.GetFromJsonAsync<List<FacilityReport>>($"Report/facility?start={start:yyyy-MM-dd}&end={end:yyyy-MM-dd}");
            return result ?? new List<FacilityReport>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new List<FacilityReport>();
        }
    }
}