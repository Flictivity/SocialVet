using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Queries.Employee;

namespace SoVet.WebAPI.Controllers;

public class EmployeeController : AuthorizedControllerBase
{
    private readonly ISender _sender;
    [HttpGet]
    public async Task<IActionResult> GetDoctors()
    {
        throw new NotImplementedException();
    }
}