using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services;

public interface IClinicService
{
    public Task<Clinic?> GetClinicInfoAsync();
    public Task<BaseResult> UpdateClinicAsync(Clinic clinic);
}