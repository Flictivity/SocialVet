using SoVet.Domain.Models;

namespace SoVet.Data.Repositories;

public interface IClinicRepository
{
    public Task<Clinic?> GetClinicInfo();
}