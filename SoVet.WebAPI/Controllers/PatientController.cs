using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Queries.Patient;

namespace SoVet.WebAPI.Controllers;

public sealed class PatientController : AuthorizedControllerBase
{
    private readonly ISender _sender;

    public PatientController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [Route("patients")]
    public async Task<IActionResult> GetPatients([FromQuery] int? clientId)
    {
        var command = new GetPatientsQuery(clientId);
        var commandResult = await _sender.Send(command);

        return Ok(commandResult);
    }
}