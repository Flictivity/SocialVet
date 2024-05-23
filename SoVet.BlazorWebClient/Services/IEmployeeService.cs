using SoVet.BlazorWebClient.Models.Employee;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services;

public interface IEmployeeService
{
    public Task<List<Employee>?> GetVeterinarians();
    public Task<List<EmployeeUser>?> GetEmployees();
    public Task<EmployeeUser?> GetEmployee(string email);
    public Task<BaseResult> CreateEmployee(EmployeeUser employeeUser);
    public Task<BaseResult> UpdateEmployee(EmployeeUser employeeUser, string oldEmail);
}