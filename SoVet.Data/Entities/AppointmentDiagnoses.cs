using System.ComponentModel.DataAnnotations.Schema;

namespace SoVet.Data.Entities;

public sealed class AppointmentDiagnoses
{
    public int Id { get; set; }
    
    public int Result { get; set; }
    public DateOnly EditDate { get; set; }
    public int AppointmentId { get; set; }
    [ForeignKey(nameof(AppointmentId))]
    public Appointment Appointment { get; set; } = null!;
    public int DiagnosisId { get; set; }
    [ForeignKey(nameof(DiagnosisId))]
    public Diagnosis Diagnosis { get; set; } = null!;
}