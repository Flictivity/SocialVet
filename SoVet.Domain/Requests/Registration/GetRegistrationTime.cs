namespace SoVet.Domain.Requests.Registration;

public sealed class GetRegistrationTime
{
    public int EmployeeId { get; set; }
    public DateOnly RegistrationDate { get; set; }
}