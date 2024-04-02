namespace SoVet.Domain.Models;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
    public string? Email { get; set; }
    public bool IsDeleted { get; set; }
}