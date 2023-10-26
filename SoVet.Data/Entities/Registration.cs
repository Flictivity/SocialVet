namespace SoVet.Data.Entities;

/// <summary>
/// Сущность Запись
/// </summary>
public sealed class Registration
{
    public int Id { get; set; }
    public string? Comment { get; set; }
    public DateTime StartTime { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;

    public int RegistrationTypeId { get; set; }
    public RegistrationType RegistrationType { get; set; } = null!;

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
}