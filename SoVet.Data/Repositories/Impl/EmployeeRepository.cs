using SoVet.Data.Mappers;
using SoVet.Domain.Models;

namespace SoVet.Data.Repositories.Impl;

public sealed class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationContext _context;
    private readonly DatabaseMapper _mapper;

    public EmployeeRepository(ApplicationContext context)
    {
        _context = context;
        _mapper = new DatabaseMapper();
    }

    public Task<List<Employee>> GetEmployeesByIds(int[] employeeIds)
    {
        var employees = _context.Employees.Where(employee => employeeIds.Contains(employee.Id))
            .Select(employee => _mapper.Map(employee)).ToList();
        return Task.FromResult(employees);
    }
}