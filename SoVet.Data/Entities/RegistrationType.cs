namespace SoVet.Data.Entities;

/// <summary>
/// Сущность Тип записи
/// </summary>
public sealed class RegistrationType
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Registration> Appointments { get; set; } = new List<Registration>();
}