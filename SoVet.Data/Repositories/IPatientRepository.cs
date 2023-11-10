namespace SoVet.Data.Repositories;

public interface IPatientRepository
{
    public Task<List<Domain.Models.Patient>> GetPatients(int? clientId);
}