using SoVet.Domain.Models;
using SoVet.Domain.Responses;

namespace SoVet.Data.Repositories;

public interface IAppointmentRepository
{
    public Task<List<AppointmentTable>> GetAppointmentsAsync(int patientId);
    public Task<Appointment?> GetAppointmentAsync(int appointmentId);
    public Task<BaseResponse> SaveAppointmentAsync(Appointment appointment);
}