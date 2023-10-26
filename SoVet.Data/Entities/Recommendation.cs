namespace SoVet.Data.Entities;

public sealed class Recommendation
{
    public int Id { get; set; }
    public string? TreatmentPlan { get; set; }
    public string? RecommendationsForCare { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = null!;
}