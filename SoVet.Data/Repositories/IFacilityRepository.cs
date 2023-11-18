using SoVet.Domain.Models;
using SoVet.Domain.Responses;

namespace SoVet.Data.Repositories;

public interface IFacilityRepository
{
    public Task<BaseResponse> SaveFacilityInAppointmentAsync(AppointmentFacility facility);
    public Task<BaseResponse> DeleteFacilityInAppointmentAsync(int appointmentFacilityId);
    public Task<List<AppointmentFacility>> GetFacilitiesInAppointment(int appointmentId);
    public Task<List<Facility>> GetFacilitiesAsync();
}