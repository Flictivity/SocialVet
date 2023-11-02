using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Queries.Registration;
using SoVet.Domain.Requests.Registration;

namespace SoVet.WebAPI.Controllers;

public sealed class RegistrationController : AuthorizedControllerBase
{
    private readonly ISender _sender;

    public RegistrationController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAvailableRegistrationTimes([FromQuery(Name = "employeeId")] int employeeId,
        [FromQuery(Name = "date")] DateOnly registrationDate)
    {
        var command = new GetAvailableRegistrationTimesQuery(employeeId, registrationDate);
        var commandResult = await _sender.Send(command);
        if (commandResult is null)
            return BadRequest();
        return Ok(commandResult);
    }
}