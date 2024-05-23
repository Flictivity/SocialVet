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
    public ICollection<AppointmentDiagnoses> AppointmentDiagnosis { get; set; } = new List<AppointmentDiagnoses>();
}