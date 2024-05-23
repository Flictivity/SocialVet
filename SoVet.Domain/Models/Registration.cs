namespace SoVet.Domain.Models;

public sealed class Registration
{
    public int Id { get; set; }
    public string? Comment { get; set; }
    public DateTime StartTime { get; set; }
    public int ClientId { get; set; }
    public string? ClientName { get; set; }
    public int EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public string? PatientName { get; set; }
    public DateTime AppointmentChangeDate { get; set; }
}