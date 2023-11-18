namespace SoVet.Domain.SqlQueries;

public static class FacilityRepositoryQueries
{
    public const string GetFacilitiesInAppointment = @"SELECT ap.id, ap.count, ap.discount, ap.sum, ap.appointment_id as AppointmentId, f.* FROM appointment_facilities ap
                                                        JOIN facilities f on f.id = ap.facility_id
                                                        WHERE ap.appointment_id = @appointmentId";
}