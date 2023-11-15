using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Queries.Client;
using SoVet.Domain.Queries.Employee;

namespace SoVet.WebAPI.Controllers;

public class ClientController : AuthorizedControllerBase
{
    private readonly ISender _sender;

    public ClientController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var userCommand = new GetClientsUserQuery();
        var userCommandResult = await _sender.Send(userCommand);
        var clientCommand = new GetClientsQuery(userCommandResult);
        var res = await _sender.Send(clientCommand);
        return Ok(res);
    }
}