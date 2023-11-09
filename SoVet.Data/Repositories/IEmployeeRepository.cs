using SoVet.Domain.Models;

namespace SoVet.Data.Repositories;

public interface IEmployeeRepository
{
    public Task<List<Employee>> GetEmployeesByIds(int[] employeeIds);
    public Task<List<EmployeeUser>> GetEmployees(List<UserInfo> users);
    public Task<Employee> CreateEmployee(Employee employee);
    public Task<Employee> UpdateEmployee(Employee employee);
}