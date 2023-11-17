using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Models.Appointment;

namespace SoVet.BlazorWebClient.Services.Impl;

public sealed class AppointmentService : IAppointmentService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AppointmentService> _logger;

    public AppointmentService(HttpClient httpClient, ILogger<AppointmentService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<AppointmentTable>> GetAppointments(int patientId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<AppointmentTable>>($"Appointment/appointments/?patientId={patientId}");
            return response ?? new List<AppointmentTable>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new List<AppointmentTable>();
        }
    }

    public async Task<Appointment?> GetAppointment(int appointmentId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<Appointment>($"Appointment/appointment/?appointmentId={appointmentId}");
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<List<Diagnosis>?> GetAppointmentDiagnoses(int appointmentId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<Diagnosis>>($"Appointment/diagnoses/?appointmentId={appointmentId}");
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }
}