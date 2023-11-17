namespace SoVet.Domain.SqlQueries;

public static class DiagnosisRepositoryQueries
{
    public const string GetDiagnoses = @"SELECT d.id, d.name, d.description, d.date, d.result, d.appointment_id as AppointmentId 
                                            FROM diagnoses d WHERE d.appointment_id = @appointmentId";
}