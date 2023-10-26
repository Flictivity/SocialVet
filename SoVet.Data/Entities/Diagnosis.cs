namespace SoVet.Data.Entities;

/// <summary>
/// Сущность Диагноз
/// </summary>
public sealed class Diagnosis
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public ICollection<AppointmentDiagnosis> AppointmentDiagnoses { get; set; } = new List<AppointmentDiagnosis>();
}