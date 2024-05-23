using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Commands.Clinic;
using SoVet.Domain.Models;
using SoVet.Domain.Queries.Clinic;

namespace SoVet.WebAPI.Controllers;

public sealed class ClinicController : AuthorizedControllerBase
{
    private readonly ISender _sender;

    public ClinicController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetClinicInfo()
    {
        var getClinicInfoCommand = new GetClinicInfoQuery();
        var commandResult = await _sender.Send(getClinicInfoCommand);
        if (commandResult is null)
            return BadRequest();
        return Ok(commandResult);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateClinicInfo([FromBody] Clinic clinic)
    {
        var updateClinicCommand = new UpdateClinicInfoCommand(clinic);
        var commandResult = await _sender.Send(updateClinicCommand);
        if (!commandResult.IsSuccess)
            return BadRequest();
        return Ok(commandResult);
    }
}