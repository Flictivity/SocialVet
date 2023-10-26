namespace SoVet.Data.Entities;

/// <summary>
/// Сущность Клиент (Владелец животного)
/// </summary>
public sealed class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Address { get; set; }

    public ICollection<Patient> Patients { get; set; } = new List<Patient>();
    public ICollection<Registration> Appointments { get; set; } = new List<Registration>();
}