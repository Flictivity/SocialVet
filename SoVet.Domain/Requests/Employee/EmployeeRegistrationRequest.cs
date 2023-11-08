namespace SoVet.Domain.Requests.Employee;

public sealed class EmployeeRegistrationRequest
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
}