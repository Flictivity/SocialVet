namespace SoVet.Domain.SqlQueries;

public static class AppointmentRepositoryQueries
{
    public const string GetAppointments = @"SELECT a.id, a.creation_date as CreationDate, e.name as VeterinarianName, e.id VeterinarianId, a.appointment_status 
                                                FROM appointments a
                                                    JOIN public.employees e on e.id = a.employee_id
                                                    WHERE a.patient_id = @patientId";
}