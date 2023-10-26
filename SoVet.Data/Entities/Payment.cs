namespace SoVet.Data.Entities;

/// <summary>
/// Сущность Платеж
/// </summary>
public sealed class Payment
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public decimal Sum { get; set; }
    public int PaymentType { get; set; }

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = null!;
}