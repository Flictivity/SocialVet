using System.ComponentModel.DataAnnotations.Schema;

namespace SoVet.Data.Entities;

/// <summary>
/// Сущность услуга
/// </summary>
public sealed class Facility
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Cost { get; set; }
    
    public bool IsDeleted { get; set; }
    public int FacilityCategoryId { get; set; }
    [ForeignKey(nameof(FacilityCategoryId))]
    public FacilityCategory FacilityCategory { get; set; } = null!;

    public ICollection<AppointmentFacility> AppointmentFacilities { get; set; } = new List<AppointmentFacility>();
}