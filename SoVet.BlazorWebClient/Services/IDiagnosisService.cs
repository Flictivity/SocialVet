using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services;

public interface IDiagnosisService
{
    public Task<BaseResult> SaveDiagnosis(Diagnosis diagnosis);
    public Task<BaseResult> SaveDiagnosisInAppointment(AppointmentDiagnoses appointmentDiagnoses);
    public Task<BaseResult> DeleteDiagnosisInAppointment(int appointmentDiagnosisId);
    public Task<BaseResult> DeleteDiagnosis(int diagnosisId);
    public Task<List<Diagnosis>?> GetDiagnoses();
}