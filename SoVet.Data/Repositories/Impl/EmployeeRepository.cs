using SoVet.Domain.Models;

namespace SoVet.Data.Repositories.Impl;

public sealed class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationContext _context;

    public EmployeeRepository(ApplicationContext context)
    {
        _context = context;
    }

    public Task<List<Employee>> GetEmployeesByIds(int[] veterinariansIds)
    {
        throw new NotImplementedException();
    }
}