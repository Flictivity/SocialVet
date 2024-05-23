namespace SoVet.Domain.SqlQueries;

public static class FacilityRepositoryQueries
{
    public const string GetFacilitiesInAppointment = @"SELECT ap.id, ap.count, ap.discount, ap.sum, ap.appointment_id as AppointmentId, f.* FROM appointment_facilities ap
                                                        JOIN facilities f on f.id = ap.facility_id
                                                        WHERE ap.appointment_id = @appointmentId";
    public const string GetFacilities = @"SELECT f.id, f.name, f.cost, f.is_deleted as IsDeleted, fc.* FROM facilities f JOIN facility_categories fc ON f.facility_category_id = fc.id
                                            WHERE not f.is_deleted";

    public const string GetReport = @"SELECT f.name as FacilityName, f.cost as FacilityCost, fc.name as FacilityCategoryName, SUM(af.count) as UseCount, SUM(af.sum) as Sum FROM appointment_facilities af
                                        JOIN facilities f on f.id = af.facility_id
                                        JOIN facility_categories fc on fc.id = f.facility_category_id
                                        JOIN appointments a on af.appointment_id = a.id
                                        WHERE a.change_date::date >= @start and a.change_date::date <= @end
                                        GROUP BY f.name, f.cost, fc.name";
}