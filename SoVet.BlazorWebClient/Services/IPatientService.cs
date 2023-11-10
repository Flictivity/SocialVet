using SoVet.BlazorWebClient.Models;

namespace SoVet.BlazorWebClient.Services;

public interface IPatientService
{
    public Task<List<Patient>?> GetPatients(int? clientId);
}