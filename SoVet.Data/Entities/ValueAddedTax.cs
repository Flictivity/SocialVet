namespace SoVet.Data.Entities;

/// <summary>
/// Сущность НДС
/// </summary>
public sealed class ValueAddedTax
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Value { get; set; }

    public ICollection<Facility> Facilities { get; set; } = new List<Facility>();
}