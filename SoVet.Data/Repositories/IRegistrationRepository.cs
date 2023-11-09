using SoVet.Domain.Models;
using SoVet.Domain.Responses;

namespace SoVet.Data.Repositories;

public interface IRegistrationRepository
{
    public Task<List<TimeSpan>?> GetTimes(int employeeId, DateOnly registrationDate);
    public Task<BaseResponse> CreateRegistration(Registration registration);
}