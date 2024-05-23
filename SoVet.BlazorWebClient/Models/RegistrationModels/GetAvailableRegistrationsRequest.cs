namespace SoVet.BlazorWebClient.Models.RegistrationModels;

public sealed class GetAvailableRegistrationsRequest
{
    public int EmployeeId { get; set; }
    public DateOnly RegistrationDate { get; set; }
}