using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Auth.Models;
using SoVet.Domain.Commands.Employee;
using SoVet.Domain.ErrorMessages;
using SoVet.Domain.Models;
using SoVet.Domain.Queries.Employee;
using SoVet.Domain.Requests.Employee;
using SoVet.Domain.Responses;

namespace SoVet.WebAPI.Controllers;

public class EmployeeController : AuthorizedControllerBase
{
    private readonly ISender _sender;

    public EmployeeController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [Route("veterinarians")]
    public async Task<IActionResult> GetDoctors()
    {
        var command = new GetEmployeesByRoleQuery(Role.Veterinarian, UserClaims.EmployeeId);
        var res = await _sender.Send(command);
        return Ok(res);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var command = new GetEmployeesQuery();
        var res = await _sender.Send(command);
        return Ok(res);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeRegistrationRequest employeeRegistration)
    {
        var newEmployee = new Employee
        {
            Name = employeeRegistration.Name
        };
        var command = new CreateEmployeeCommand(newEmployee, employeeRegistration.Email, employeeRegistration.Role);
        try
        {
            var commandResult = await _sender.Send(command);
            if (!commandResult.IsSuccess)
                return BadRequest(new BaseResponse{ IsSuccess = false, Message = EmployeeErrorMessages.EmployeeRegistrationError});
        
            return Ok(new BaseResponse{IsSuccess = true});
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseResponse{ IsSuccess = false, Message = ex.Message});
        }
    }
    
    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeRegistrationRequest employeeRegistration)
    {
        var newEmployee = new Employee
        {
            Id = employeeRegistration.Id,
            Name = employeeRegistration.Name
        };
        var command = new UpdateEmployeeCommand(newEmployee, employeeRegistration.OldEmail, employeeRegistration.Email, employeeRegistration.Role, employeeRegistration.Password);
        try
        {
            var commandResult = await _sender.Send(command);
            if (!commandResult.IsSuccess)
                return BadRequest(new BaseResponse{ IsSuccess = false, Message = EmployeeErrorMessages.EmployeeRegistrationError});
        
            return Ok(new BaseResponse{IsSuccess = true});
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseResponse{ IsSuccess = false, Message = ex.Message});
        }
    }
}