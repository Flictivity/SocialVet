using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Commands.Report;

namespace SoVet.WebAPI.Controllers;

public sealed class ReportController : AuthorizedControllerBase
{
    private readonly ISender _sender;

    public ReportController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    [Route("appointments-statuses-info")]
    public async Task<IActionResult> AppointmentsStatusesInfo()
    {
        var command = new GetAppointmentsStatusesInfoCommand();
        var commandResult = await _sender.Send(command);
        return Ok(commandResult);
    }
    
    [HttpGet]
    [Route("appointments-in-year")]
    public async Task<IActionResult> AppointmentsInYear([FromQuery] int year)
    {
        var command = new GetAppointmentsInYearCommand(year);
        var commandResult = await _sender.Send(command);
        return Ok(commandResult);
    }
    
    [HttpGet]
    [Route("appointments-in-month-count")]
    public async Task<IActionResult> AppointmentsInMonthCount()
    {
        var command = new GetAppointmentsInMonthCountCommand();
        var commandResult = await _sender.Send(command);
        return Ok(commandResult);
    }
}