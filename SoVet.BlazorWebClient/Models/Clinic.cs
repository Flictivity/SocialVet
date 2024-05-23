namespace SoVet.BlazorWebClient.Models;

public sealed class Clinic
{
    public int Id { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public string ClinicName { get; set; } = null!;
    public double AppointmentDuration { get; set; } = 0.5;
    public double PauseDuration { get; set; } = 30;
}