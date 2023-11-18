namespace SoVet.Domain.Models;

public sealed class Facility
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Cost { get; set; }
    public FacilityCategory? FacilityCategory { get; set; } = null!;
}