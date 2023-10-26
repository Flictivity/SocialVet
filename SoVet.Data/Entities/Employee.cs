namespace SoVet.Data.Entities;

/// <summary>
/// Сущность Сотрудник
/// </summary>
public sealed class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}