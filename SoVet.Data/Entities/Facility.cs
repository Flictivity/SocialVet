namespace SoVet.Data.Entities;

/// <summary>
/// Сущность услуга
/// </summary>
public sealed class Facility
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Cost { get; set; }

    public int FacilityCategoryId { get; set; }
    public FacilityCategory FacilityCategory { get; set; } = null!;

    public int ValueAddedTaxId { get; set; }
    public ValueAddedTax ValueAddedTax { get; set; } = null!;

    public ICollection<AppointmentFacility> AppointmentFacilities { get; set; } = new List<AppointmentFacility>();
}