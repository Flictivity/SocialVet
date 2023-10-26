namespace SoVet.Data.Entities;

/// <summary>
/// Сущность Категория услуги
/// </summary>
public sealed class FacilityCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Facility> Facilities { get; set; } = new List<Facility>();
}