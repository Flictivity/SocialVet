using SoVet.BlazorWebClient.Models.Registration;

namespace SoVet.BlazorWebClient.Services;

public interface IRegistrationService
{
    Task<List<TimeSpan>?> GetAvailableRegistrationTimes(GetAvailableRegistrationsRequest request);
}