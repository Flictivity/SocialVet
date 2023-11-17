using SoVet.Domain.Models;

namespace SoVet.Data.Repositories;

public interface IDiagnosisRepository
{
    public Task<List<Diagnosis>> GetDiagnosesAsync(int appointmentId);
}