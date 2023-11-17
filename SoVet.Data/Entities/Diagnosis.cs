using System.ComponentModel.DataAnnotations.Schema;

namespace SoVet.Data.Entities;

/// <summary>
/// Сущность Диагноз
/// </summary>
public sealed class Diagnosis
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateOnly Date { get; set; }
    public int Result { get; set; }
    public int AppointmentId { get; set; }
    [ForeignKey(nameof(AppointmentId))] 
    public Appointment Appointment { get; set; } = null!;
}