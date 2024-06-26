﻿using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Models.Appointment;
using SoVet.BlazorWebClient.Results;

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

    public async Task<List<AppointmentDiagnoses>?> GetAppointmentDiagnoses(int appointmentId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<AppointmentDiagnoses>>($"Appointment/diagnoses/?appointmentId={appointmentId}");
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<List<AppointmentFacility>?> GetAppointmentFacilities(int appointmentId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<AppointmentFacility>>($"Appointment/facilities/?appointmentId={appointmentId}");
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<BaseResult> SaveAppointment(Appointment appointment)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("Appointment/save", appointment);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            return result ?? new BaseResult {IsSuccess = false, Message = "Произошла ошибка при сохранении приема"};
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BaseResult {IsSuccess = false, Message = ex.Message};
        }
    }

    public async Task<Appointment?> GetAppointmentByRegistration(int registrationId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<Appointment?>($"Appointment/registration/?registrationId={registrationId}");
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }
}