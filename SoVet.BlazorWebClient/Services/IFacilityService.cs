using SoVet.BlazorWebClient.Models;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services;

public interface IFacilityService
{
    public Task<BaseResult> SaveFacilityInAppointment(AppointmentFacility appointmentFacility);
    public Task<BaseResult> DeleteFacilityInAppointment(int appointmentFacilityId);
    public Task<List<Facility>?> GetFacilities();
    public Task<List<FacilityCategory>?> GetFacilityCategories();
}