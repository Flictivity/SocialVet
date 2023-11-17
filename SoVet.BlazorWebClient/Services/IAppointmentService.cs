using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Models.Appointment;

namespace SoVet.BlazorWebClient.Services;

public interface IAppointmentService
{
    public Task<List<AppointmentTable>> GetAppointments(int patientId);
    public Task<Appointment?> GetAppointment(int appointmentId);
    public Task<List<Diagnosis>?> GetAppointmentDiagnoses(int appointmentId);
}