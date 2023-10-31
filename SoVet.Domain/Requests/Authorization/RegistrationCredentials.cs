namespace SoVet.Domain.Requests.Authorization;

public sealed class RegistrationCredentials
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Address { get; set; } = null!;
}