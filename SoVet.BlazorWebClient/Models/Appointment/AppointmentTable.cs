namespace SoVet.BlazorWebClient.Models.Appointment;

public sealed class AppointmentTable
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public string VeterinarianName { get; set; } = null!;
    public int VeterinarianId { get; set; }
    public int Status { get; set; }
}