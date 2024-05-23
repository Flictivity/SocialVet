namespace SoVet.Domain.Models;

public sealed class TokenDTO
{
    public string? Token { get; set; }
    public DateTime? Expiration { get; set; }
}