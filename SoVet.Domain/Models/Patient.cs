namespace SoVet.Domain.Models;

public sealed class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public int AnimalTypeId { get; set; }
    public string AnimalTypeName { get; set; } = null!;
    public int ClientId { get; set; }
    public string ClientName { get; set; } = null!;
    public string? Comment { get; set; }
}