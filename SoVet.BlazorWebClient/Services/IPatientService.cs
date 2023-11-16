using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services;

public interface IPatientService
{
    public Task<List<Patient>?> GetPatients(int? clientId = null);
    public Task<BaseResult> UpdatePatient(Patient patient);
    public Task<BaseResult> CreatePatient(Patient patient);
}