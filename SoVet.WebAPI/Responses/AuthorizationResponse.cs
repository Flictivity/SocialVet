using SoVet.Domain.Models;

namespace SoVet.WebAPI.Responses;

public sealed class AuthorizationResponse
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string? Token { get; set; }
}