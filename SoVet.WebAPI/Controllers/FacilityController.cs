using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Commands.Facility;
using SoVet.Domain.Models;
using SoVet.Domain.Queries.Facility;

namespace SoVet.WebAPI.Controllers;

public sealed class FacilityController : AuthorizedControllerBase
{
    private readonly ISender _sender;

    public FacilityController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("save-in-appointment")]
    public async Task<IActionResult> SaveFacilityInAppointment([FromBody] AppointmentFacility facility)
    {
        var command = new SaveFacilityCommand(facility);
        var result = await _sender.Send(command);
        return Ok(result);
    }

    [HttpPut("delete-in-appointment")]
    public async Task<IActionResult> DeleteFacilityInAppointment([FromBody] int appointmentFacilityId)
    {
        var command = new DeleteFacilityCommand(appointmentFacilityId);
        var result = await _sender.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetFacilities()
    {
        var command = new GetFacilitiesQuery();
        var result = await _sender.Send(command);
        return Ok(result);
    }
    
    [HttpGet("facility-categories")]
    public async Task<IActionResult> GetFacilityCategories()
    {
        var command = new GetFacilityCategoriesQuery();
        var result = await _sender.Send(command);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateFacility([FromBody] Facility facility)
    {
        var updateFacilityCommand = new UpdateFacilityCommand(facility);
        var commandResult = await _sender.Send(updateFacilityCommand);
        if (!commandResult.IsSuccess)
            return BadRequest();
        return Ok(commandResult);
    }
    [HttpPut("update-facility-category")]
    public async Task<IActionResult> UpdateFacilityCategory([FromBody] FacilityCategory facilityCategory)
    {
        var updateFacilityCategoryCommand = new UpdateFacilityCategoryCommand(facilityCategory);
        var commandResult = await _sender.Send(updateFacilityCategoryCommand);
        if (!commandResult.IsSuccess)
            return BadRequest();
        return Ok(commandResult);
    }
}