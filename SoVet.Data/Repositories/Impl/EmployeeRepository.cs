using Dapper;
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

    public Task<List<EmployeeUser>> GetEmployees(List<UserInfo> users)
    {
        var employees = _context.Employees.AsList();
        var res = (from employee in employees
                let employeeUser = users.FirstOrDefault(x => x.Id == employee.Id)
                where employeeUser is not null
                select new EmployeeUser
                    { Id=employeeUser.Id, Name = employee.Name, Email = employeeUser.Email, Role = employeeUser.RoleName })
            .ToList();

        return Task.FromResult(res);
    }

    public Task<EmployeeUser?> GetEmployee(List<UserInfo> users, string email)
    {
        var employeeUser = users.FirstOrDefault(x => x.Email == email);
        if (employeeUser is null)
            return Task.FromResult<EmployeeUser?>(null);
        var client = _context.Employees.FirstOrDefault(x => x.Id == employeeUser.Id);
        return Task.FromResult(client is null ? null : new EmployeeUser
            { Id = client.Id, Name = client.Name, Email = employeeUser.Email, Role = employeeUser.RoleName});
    }

    public async Task<Employee> CreateEmployee(Employee employee)
    {
        var employeeDb = _mapper.Map(employee);
        await _context.Employees.AddAsync(employeeDb);
        await _context.SaveChangesAsync();
        return _mapper.Map(employeeDb);
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        _context.ChangeTracker.Clear();
        var employeeDb = _mapper.Map(employee);
        _context.Employees.Update(employeeDb);
        await _context.SaveChangesAsync();
        return _mapper.Map(employeeDb);
    }
}