namespace SoVet.Data.Repositories;

public interface IRegistrationRepository
{
    Task<List<TimeSpan>?> GetTimes(int employeeId, DateOnly registrationDate);
}