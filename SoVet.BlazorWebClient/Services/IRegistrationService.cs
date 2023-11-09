using SoVet.BlazorWebClient.Models.Registration;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services;

public interface IRegistrationService
{
    public Task<List<TimeSpan>?> GetAvailableRegistrationTimes(GetAvailableRegistrationsRequest request);
    public Task<BaseResult> CreateRegistration(RegistrationCreateRequest request);
}