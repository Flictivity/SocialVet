using SoVet.Domain.Models;
using SoVet.Domain.Responses;

namespace SoVet.Data.Repositories;

public interface IPatientRepository
{
    public Task<List<Patient>> GetPatients(int? clientId);
    public Task<BaseResponse> CreatePatient(Patient patient);
    public Task<BaseResponse> UpdatePatient(Patient patient);
}