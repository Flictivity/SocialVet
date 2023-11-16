using SoVet.BlazorWebClient.Models.Appointment;

namespace SoVet.BlazorWebClient.Services;

public interface IAppointmentService
{
    public Task<List<AppointmentTable>> GetAppointments(int patientId);
}