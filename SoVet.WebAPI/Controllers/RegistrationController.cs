using System.Globalization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Commands.Registration;
using SoVet.Domain.Models;
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
    [Route("available-times")]
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

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateRegistration([FromBody] CreateRegistrationRequest request)
    {
        var newRegistration = new Registration
        {
            Comment = request.Comment,
            StartTime = request.StartTime,
            ClientId = request.ClientId,
            EmployeeId = request.EmployeeId,
        };
        var command = new CreateRegistrationCommand(newRegistration);
        var result = await _sender.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetRegistrations([FromQuery(Name = "employeeId")] int? employeeId)
    {
        var command = new GetRegistrationsQuery(employeeId);
        var commandResult = await _sender.Send(command);
        if (commandResult is null)
            return BadRequest();
        return Ok(commandResult);
    }
}