using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Auth.Models;
using SoVet.Domain.Commands.Client;
using SoVet.Domain.ErrorMessages;
using SoVet.Domain.Models;
using SoVet.Domain.Queries.Client;
using SoVet.Domain.Responses;

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
    
    [HttpPost("update")]
    public async Task<IActionResult> UpdateClient([FromBody] Client client, [FromQuery] string oldEmail, [FromQuery] string? password)
    {
        var command = new UpdateClientCommand(client, oldEmail, password, Role.Client);
        try
        {
            var commandResult = await _sender.Send(command);
            if (!commandResult.IsSuccess)
                return BadRequest(new BaseResponse{ IsSuccess = false, Message = EmployeeErrorMessages.EmployeeRegistrationError});
        
            return Ok(new BaseResponse{IsSuccess = true});
        }
        catch (Exception ex)
        {
            return BadRequest(new BaseResponse{ IsSuccess = false, Message = ex.Message});
        }
    }
    
    [HttpGet("client")]
    public async Task<IActionResult> GetClient([FromQuery] string clientEmail)
    {
        var userCommand = new GetClientsUserQuery();
        var userCommandResult = await _sender.Send(userCommand);
        var command = new GetClientCommand(userCommandResult, clientEmail);
        var result = await _sender.Send(command);
        return Ok(result);
    }
}