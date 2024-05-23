namespace SoVet.BlazorWebClient.Models.Appointment;

public sealed class Appointment
{
    public int Id { get; set; }
    public string Purpose { get; set; } = null!;
    public string? Anamnesis { get; set; }
    public string? Information { get; set; }
    public DateTime ChangeDate { get; set; }
    public DateTime CreationDate { get; set; }
    public int AppointmentStatus { get; set; }
    public Employee.Employee Employee { get; set; } = null!;
    public string? Recommendations { get; set; }
    public int RegistrationId { get; set; }
    public int PatientId { get; set; }
}