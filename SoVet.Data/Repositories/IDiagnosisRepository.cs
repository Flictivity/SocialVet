using SoVet.Domain.Models;
using SoVet.Domain.Responses;
using Diagnosis = SoVet.Domain.Models.Diagnosis;

namespace SoVet.Data.Repositories;

public interface IDiagnosisRepository
{
    public Task<List<AppointmentDiagnoses>> GetAppointmentDiagnosesAsync(int appointmentId);
    public Task<BaseResponse> SaveDiagnosisAsync(Diagnosis diagnosis);
    public Task<BaseResponse> DeleteDiagnosisAsync(int diagnosisId);
    public Task<BaseResponse> DeleteDiagnosisInAppointmentAsync(int appointmentDiagnosisId);
    public Task<BaseResponse> SaveDiagnosisInAppointmentAsync(AppointmentDiagnoses appointmentDiagnosis);
    public Task<List<Diagnosis>> GetDiagnosesAsync();
}