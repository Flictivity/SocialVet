namespace SoVet.Data.Entities;

/// <summary>
/// Сущность Прием
/// </summary>
public sealed class Appointment
{
    public int Id { get; set; }
    public string Purpose { get; set; } = null!;
    public string? Anamnesis { get; set; }
    public string? Information { get; set; }
    public DateTime ChangeDate { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public int RecommendationId { get; set; }
    public Recommendation Recommendation { get; set; } = null!;

    public ICollection<AppointmentFacility> AppointmentFacilities { get; set; } = new List<AppointmentFacility>();
    public ICollection<AppointmentDiagnosis> AppointmentDiagnoses { get; set; } = new List<AppointmentDiagnosis>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}