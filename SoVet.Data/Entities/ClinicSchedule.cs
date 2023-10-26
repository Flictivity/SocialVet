namespace SoVet.Data.Entities;

/// <summary>
/// Сущность Расписание клиники
/// </summary>
public sealed class ClinicSchedule
{
    public int Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}