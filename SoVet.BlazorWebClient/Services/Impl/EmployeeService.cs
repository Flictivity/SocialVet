using System.Net.Http.Json;
using SoVet.BlazorWebClient.Models.Employee;
using SoVet.BlazorWebClient.Results;

namespace SoVet.BlazorWebClient.Services.Impl;

public sealed class EmployeeService : IEmployeeService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<EmployeeService> _logger;

    public EmployeeService(HttpClient http, ILogger<EmployeeService> logger)
    {
        _httpClient = http;
        _logger = logger;
    }

    public async Task<List<Employee>?> GetVeterinarians()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>("Employee/veterinarians");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<List<EmployeeUser>?> GetEmployees()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<EmployeeUser>>("Employee");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<BaseResult> CreateEmployee(EmployeeUser employeeUser)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("Employee/create", employeeUser);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            return result ?? new BaseResult {IsSuccess = false, Message = "Произошла ошибка при добавлении сотрудника"};
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BaseResult {IsSuccess = false, Message = ex.Message};
        }
    }

    public async Task<BaseResult> UpdateEmployee(EmployeeUser employeeUser, string oldEmail)
    {
        try
        {
            employeeUser.OldEmail = oldEmail;
            var response = await _httpClient.PutAsJsonAsync("Employee/update", employeeUser);
            var result = await response.Content.ReadFromJsonAsync<BaseResult>();
            return result ?? new BaseResult {IsSuccess = false, Message = "Произошла ошибка при обновлении"};
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BaseResult {IsSuccess = false, Message  = "Произошла ошибка при обновлении"};
        }
    }
}