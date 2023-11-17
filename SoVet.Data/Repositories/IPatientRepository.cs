using SoVet.Domain.Models;
using SoVet.Domain.Responses;

namespace SoVet.Data.Repositories;

public interface IPatientRepository
{
    public Task<List<Patient>> GetPatientsAsync(int? clientId);
    public Task<Patient?> GetPatientAsync(int patientId);
    public Task<BaseResponse> CreatePatientAsync(Patient patient);
    public Task<BaseResponse> UpdatePatientAsync(Patient patient);
}