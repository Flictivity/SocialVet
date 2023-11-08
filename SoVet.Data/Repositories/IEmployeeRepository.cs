using SoVet.Domain.Models;
using SoVet.Domain.Requests.Employee;
using SoVet.Domain.Responses;

namespace SoVet.Data.Repositories;

public interface IEmployeeRepository
{
    public Task<List<Employee>> GetEmployeesByIds(int[] employeeIds);
    public Task<Employee> CreateEmployee(Employee employee);
}