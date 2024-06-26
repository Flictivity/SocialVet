﻿using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Models.Appointment;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services;

public interface IAppointmentService
{
    public Task<List<AppointmentTable>> GetAppointments(int patientId);
    public Task<Appointment?> GetAppointment(int appointmentId);
    public Task<List<AppointmentDiagnoses>?> GetAppointmentDiagnoses(int appointmentId);
    public Task<List<AppointmentFacility>?> GetAppointmentFacilities(int appointmentId);
    public Task<BaseResult> SaveAppointment(Appointment appointment);
    public Task<Appointment?> GetAppointmentByRegistration(int registrationId);
}