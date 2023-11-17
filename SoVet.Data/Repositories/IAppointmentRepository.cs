﻿using SoVet.Domain.Models;

namespace SoVet.Data.Repositories;

public interface IAppointmentRepository
{
    public Task<List<AppointmentTable>> GetAppointmentsAsync(int patientId);
    public Task<Appointment?> GetAppointmentAsync(int appointmentId);
}