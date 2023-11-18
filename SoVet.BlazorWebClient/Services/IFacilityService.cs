using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services;

public interface IFacilityService
{
    public Task<BaseResult> SaveFacilityInAppointment(AppointmentFacility appointmentFacility);
    public Task<List<Facility>> GetFacilities();
}