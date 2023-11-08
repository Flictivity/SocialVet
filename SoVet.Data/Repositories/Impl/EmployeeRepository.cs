using SoVet.Data.Mappers;
using SoVet.Domain.Models;
using SoVet.Domain.Requests.Employee;
using SoVet.Domain.Responses;

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

    public async Task<Employee> CreateEmployee(Employee employee)
    {
        var employeeDb = _mapper.Map(employee);
        await _context.Employees.AddAsync(employeeDb);
        await _context.SaveChangesAsync();
        return _mapper.Map(employeeDb);   
    }
}