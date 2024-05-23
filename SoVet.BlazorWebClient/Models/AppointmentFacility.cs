namespace SoVet.BlazorWebClient.Models;

public class AppointmentFacility
{
    public int Id { get; set; }
    public int Count { get; set; }
    public int Discount { get; set; }
    public decimal Sum { get; set; }
    public int AppointmentId { get; set; }
    public Facility? Facility { get; set; } = null!;
}