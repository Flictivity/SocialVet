using System.ComponentModel.DataAnnotations.Schema;

namespace SoVet.Data.Entities;

/// <summary>
/// Сущность Пациент
/// </summary>
public sealed class Patient
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; } = null!;
    public int AnimalType { get; set; }
    public string? Comment { get; set; }

    public int ClientId { get; set; }
    [ForeignKey(nameof(ClientId))]
    public Client Owner { get; set; } = null!;
    public ICollection<Vaccination> Vaccinations = new List<Vaccination>();
}