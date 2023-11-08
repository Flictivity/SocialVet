using SoVet.BlazorWebClient.Models.Employee;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services;

public interface IEmployeeService
{
    public Task<List<Employee>?> GetEmployees();
    public Task<BaseResult> CreateEmployee(EmployeeRegistration employeeRegistration);
}