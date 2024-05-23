namespace SoVet.Domain.Requests.Employee;

public sealed class EmployeeRegistrationRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? OldEmail { get; set; }
    public string Role { get; set; } = null!;
    public string? Password { get; set; }
}