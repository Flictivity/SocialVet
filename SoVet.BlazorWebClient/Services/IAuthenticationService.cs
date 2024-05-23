using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services;

public interface IAuthenticationService
{
    public Task<BaseResult> Register(UserRegistration userRegistration);
    public Task<BaseResult> LogOut();
    public Task<AuthorizationResult> Login(UserLogin userLogin);
}