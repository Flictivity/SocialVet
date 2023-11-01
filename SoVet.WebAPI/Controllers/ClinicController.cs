using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Commands.Clinic;

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
        var getClinicInfoCommand = new GetClinicInfoCommand();
        var commandResult = await _sender.Send(getClinicInfoCommand);
        if (commandResult is null)
            return BadRequest();
        return Ok(commandResult);
    }
}