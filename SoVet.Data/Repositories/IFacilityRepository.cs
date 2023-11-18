using SoVet.Domain.Models;
using SoVet.Domain.Responses;

namespace SoVet.Data.Repositories;

public interface IFacilityRepository
{
    public Task<BaseResponse> SaveFacilityInAppointmentAsync(AppointmentFacility facility);
    public Task<List<AppointmentFacility>> GetFacilitiesInAppointment(int appointmentId);
}