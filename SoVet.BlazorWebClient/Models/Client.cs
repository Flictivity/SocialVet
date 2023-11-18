namespace SoVet.BlazorWebClient.Models;

public sealed class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}