using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Queries.Reference;

namespace SoVet.WebAPI.Controllers;

public class AnimalTypeController : AuthorizedControllerBase
{
    private readonly ISender _sender;

    public AnimalTypeController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAnimalTypes()
    {
        var command = new GetAnimalTypeQuery();
        return Ok(await _sender.Send(command));
    }
}