namespace SoVet.Domain.Requests.Authorization;

public sealed class LoginCredentials
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}