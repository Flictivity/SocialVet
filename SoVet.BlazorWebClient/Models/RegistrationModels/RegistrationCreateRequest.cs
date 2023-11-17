namespace SoVet.BlazorWebClient.Models.RegistrationModels;

public sealed class RegistrationCreateRequest
{
    public string? Comment { get; set; }
    public DateTime StartTime { get; set; }
    public int ClientId { get; set; }
    public int EmployeeId { get; set; }
}