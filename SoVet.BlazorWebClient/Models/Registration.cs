namespace SoVet.BlazorWebClient.Models;

public sealed class Registration
{
    public string? Comment { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime => StartTime.AddHours(1);
    public int ClientId { get; set; }
    public string? ClientName { get; set; }
    public int EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public int RegistrationTypeId { get; set; }
    public string? TypeName { get; set; }
}