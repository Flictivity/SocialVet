using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Commands.Facility;
using SoVet.Domain.Models;

namespace SoVet.WebAPI.Controllers;

public sealed class FacilityController : AuthorizedControllerBase
{
    private readonly ISender _sender;

    public FacilityController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("facilities-in-appointment")]
    public async Task<IActionResult> GetFacilitiesInAppointment([FromQuery] int appointmentId)
    {
        var command = new GetFacilitiesInAppointmentQuery(appointmentId);
        var result = await _sender.Send(command);
        return Ok(result);
    }

    [HttpPost("save-in-appointment")]
    public async Task<IActionResult> SaveFacilityInAppointment([FromBody] AppointmentFacility facility)
    {
        var command = new SaveFacilityCommand(facility);
        var result = await _sender.Send(command);
        return Ok(result);
    }
    
    [HttpPut("delete-in-appointment")]
    public async Task<IActionResult> DeleteFacilityInAppointment([FromBody] int appointmentId, [FromBody] int facilityId)
    {
        // var command = new (facility);
        // var result = await _sender.Send(command);
        return Ok();
    }
}