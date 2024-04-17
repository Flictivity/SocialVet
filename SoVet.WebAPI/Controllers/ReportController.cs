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
}