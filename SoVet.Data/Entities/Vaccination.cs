namespace SoVet.Data.Entities;

/// <summary>
/// Сущьность Вакцинация
/// </summary>
public sealed class Vaccination
{
    public int Id { get; set; }
    public DateOnly DateVaccination { get; set; }
    public DateOnly DateRevaccination { get; set; }
    public string VaccineNumber { get; set; } = null!;

    /// <summary>
    /// Срок годности вакцины в месяцах
    /// </summary>
    public int ExpirationTime { get; set; }

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
}