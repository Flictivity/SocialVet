namespace SoVet.Domain.Models;

public sealed class Registration
{
    public string? Comment { get; set; }
    public DateTime StartTime { get; set; }
    public int ClientId { get; set; }
    public int EmployeeId { get; set; }
    public int RegistrationTypeId { get; set; }
}