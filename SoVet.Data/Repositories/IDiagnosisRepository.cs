using SoVet.Domain.Models;
using SoVet.Domain.Responses;

namespace SoVet.Data.Repositories;

public interface IDiagnosisRepository
{
    public Task<List<Diagnosis>> GetDiagnosesAsync(int appointmentId);
    public Task<BaseResponse> SaveDiagnosisAsync(Diagnosis diagnosis);
    public Task<BaseResponse> DeleteDiagnosisAsync(int diagnosisId);
}