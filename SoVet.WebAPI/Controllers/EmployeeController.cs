using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Auth.Models;
using SoVet.Domain.Queries.Employee;

namespace SoVet.WebAPI.Controllers;

public class EmployeeController : AuthorizedControllerBase
{
    private readonly ISender _sender;

    public EmployeeController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetDoctors()
    {
        var command = new GetEmployeesQuery(Role.Veterinarian, UserClaims.EmployeeId);
        var res = await _sender.Send(command);
        return Ok(res);
    }
}