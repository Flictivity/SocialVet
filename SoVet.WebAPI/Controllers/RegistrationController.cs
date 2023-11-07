using System.Globalization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Queries.Registration;

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
        [FromQuery(Name = "date")] string registrationDate)
    {
        if (!DateOnly.TryParseExact(registrationDate, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None,
                out var parsedDate))
        {
            return BadRequest();
        }

        var command = new GetAvailableRegistrationTimesQuery(employeeId, parsedDate);
        var commandResult = await _sender.Send(command);
        if (commandResult is null)
            return BadRequest();
        return Ok(commandResult);
    }
}