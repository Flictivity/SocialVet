using SoVet.Domain.Models;

namespace SoVet.Data.Repositories;

public interface IEmployeeRepository
{
    public Task<List<Employee>> GetEmployeesByIds(int[] employeeIds);
    public Task<List<EmployeeUser>> GetEmployees(List<UserInfo> users);
    public Task<EmployeeUser?> GetEmployee(List<UserInfo> users,string email);
    public Task<Employee> CreateEmployee(Employee employee);
    public Task<Employee> UpdateEmployee(Employee employee);
    public Task<List<EmployeeReport>> GetReport(DateTime start, DateTime end);
}