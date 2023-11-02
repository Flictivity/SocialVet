namespace SoVet.BlazorWebClient.Models.Registration;

public sealed class GetAvailableRegistrationsRequest
{
    public int EmployeeId { get; set; }
    public DateOnly RegistrationDate { get; set; }
}