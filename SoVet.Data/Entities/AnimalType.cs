namespace SoVet.Data.Entities;

public sealed class AnimalType
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public ICollection<Patient> Patients { get; set; } = new List<Patient>();
}