namespace SoVet.Domain.SqlQueries;

public static class DiagnosisRepositoryQueries
{
    public const string GetDiagnoses = @"SELECT ad.id, ad.edit_date as EditDate, ad.result, ad.appointment_id as AppointmentId, d.*
                                            FROM diagnoses d JOIN appointment_diagnoses ad on d.id = ad.diagnosis_id WHERE ad.appointment_id = @appointmentId";
}