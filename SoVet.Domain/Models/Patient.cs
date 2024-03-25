namespace SoVet.Domain.Models;

public sealed class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public AnimalType AnimalType { get; set; } = null!;
    public Client Client { get; set; } = null!;
    public string? Comment { get; set; }
}