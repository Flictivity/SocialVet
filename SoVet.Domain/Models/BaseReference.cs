namespace SoVet.Domain.Models;

public abstract class BaseReference
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}