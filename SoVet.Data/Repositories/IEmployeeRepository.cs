using SoVet.Domain.Models;

namespace SoVet.Data.Repositories;

public interface IEmployeeRepository
{
    public Task<List<Employee>> GetEmployeesByIds(int[] veterinariansIds);
}