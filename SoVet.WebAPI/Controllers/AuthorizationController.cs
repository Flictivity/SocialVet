using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Commands.Client;
using SoVet.Domain.Commands.Token;
using SoVet.Domain.Models;
using SoVet.WebAPI.Credentials.Authorization;
using SoVet.WebAPI.Responses;

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
            return BadRequest("Ошибка при регистрации клиента");

        var clientId = commandResult.Match(x => x.Id, _ => 0);
        var response = new AuthorizationResponse
        {
            Id = clientId,
            Email = credentials.Email,
            Token = await _sender.Send(new GenerateTokenCommand(credentials.Email, clientId))
        }; 
        
        return Ok(response);
    }
}