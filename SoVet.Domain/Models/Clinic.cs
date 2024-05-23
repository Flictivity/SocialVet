namespace SoVet.Domain.Models;

public sealed class Clinic
{
    public int Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string ClinicName { get; set; } = null!;
    public double AppointmentDuration { get; set; }
    public double PauseDuration { get; set; } 
}