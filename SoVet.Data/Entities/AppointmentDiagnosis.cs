using System.ComponentModel.DataAnnotations.Schema;

namespace SoVet.Data.Entities;

/// <summary>
/// Сущность Диагнозы приема
/// </summary>
public sealed class AppointmentDiagnosis
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public int Result { get; set; }
    
    public int AppointmentId { get; set; }
    [ForeignKey(nameof(AppointmentId))]
    public Appointment Appointment { get; set; } = null!;

    public int DiagnosisId { get; set; }
    [ForeignKey(nameof(DiagnosisId))]
    public Diagnosis Diagnosis { get; set; } = null!;
}