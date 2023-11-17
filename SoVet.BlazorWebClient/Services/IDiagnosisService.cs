using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services;

public interface IDiagnosisService
{
    public Task<BaseResult> SaveDiagnosis(Diagnosis diagnosis);
    public Task<BaseResult> DeleteDiagnosis(int diagnosisId);
}