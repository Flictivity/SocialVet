using SoVet.Domain.Models;
using SoVet.Domain.Responses;

namespace SoVet.Data.Repositories;

public interface IClinicRepository
{
    public Task<Clinic?> GetClinicInfo();
    public Task<BaseResponse> UpdateClinicInfo(Clinic clinic);
}