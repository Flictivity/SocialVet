namespace SoVet.Data.Entities;

/// <summary>
/// Сущность Услуги приема
/// </summary>
public sealed class AppointmentFacility
{
    public int Id { get; set; }
    public int Count { get; set; }
    public int Discount { get; set; }
    public decimal Sum { get; set; }

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = null!;

    public int FacilityId { get; set; }
    public Facility Facility { get; set; } = null!;
}