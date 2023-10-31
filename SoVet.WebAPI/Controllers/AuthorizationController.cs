using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Commands.Client;
using SoVet.Domain.Commands.Token;
using SoVet.Domain.Commands.User;
using SoVet.Domain.ErrorMessages;
using SoVet.Domain.Models;
using SoVet.Domain.Requests.Authorization;
using SoVet.Domain.Responses;
using SoVet.Domain.Responses.Authorization;

namespace SoVet.WebAPI.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("/api/[controller]")]
public class AuthorizationController : ControllerBase 
{
    private readonly ILogger<AuthorizationController> _logger;
    private readonly ISender _sender;

    public AuthorizationController(ILogger<AuthorizationController> logger, ISender sender)
    {
        _logger = logger;
        _sender = sender;
    }
    
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationCredentials credentials)
    {
        var newClient = new Client
        {
            Name = credentials.Name,
            Address = credentials.Address
        };
        
        var addClientCommand = new AddClientCommand(newClient, credentials.Email, credentials.Password);
        var commandResult = await _sender.Send(addClientCommand);
        
        if (!commandResult.IsSuccess)
            return BadRequest(new BaseResponse{ IsSuccess = false, Message = ClientErrorMessages.ClientRegistrationError});
        
        return Ok(new BaseResponse{IsSuccess = true});
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginCredentials credentials)
    {
        var loginCommand = new LoginUserCommand(credentials.Email, credentials.Password);
        var commandResult = await _sender.Send(loginCommand);
        if (!commandResult.IsSuccess)
            return BadRequest(commandResult);
        return Ok(commandResult);
    }
}