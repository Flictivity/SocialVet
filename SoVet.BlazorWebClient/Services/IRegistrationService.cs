using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Models.RegistrationModels;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services;

public interface IRegistrationService
{
    public Task<List<TimeSpan>?> GetAvailableRegistrationTimes(GetAvailableRegistrationsRequest request);
    public Task<BaseResult> CreateRegistration(RegistrationCreateRequest request);
    public Task<List<Registration>?> GetRegistrations(int? employeeId, int? clientId = null);
}