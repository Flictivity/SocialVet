using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services;

public interface IAuthenticationService
{
    public Task<UserRegistrationResult> Register(UserRegistration userRegistration);
}