using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Queries.Appointment;

namespace SoVet.WebAPI.Controllers;

public class AppointmentController : AuthorizedControllerBase
{
    private readonly ISender _sender;

    public AppointmentController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("appointments")]
    public async Task<IActionResult> GetAppointments([FromQuery] int patientId)
    {
        var command = new GetAppointmentsQuery(patientId);
        var result = await _sender.Send(command);

        return Ok(result);
    }
    
    [HttpGet("appointment")]
    public async Task<IActionResult> GetAppointment([FromQuery] int appointmentId)
    {
        var command = new GetAppointmentQuery(appointmentId);
        var result = await _sender.Send(command);

        return Ok(result);
    }
}