namespace SoVet.BlazorWebClient.Models;

public sealed class AppointmentDiagnoses
{
    public int Id { get; set; }
    
    public int Result { get; set; }
    public DateOnly EditDate { get; set; }
    public int AppointmentId { get; set; }
    public Diagnosis? Diagnosis { get; set; } = null!;
}