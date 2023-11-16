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

    [HttpGet]
    public async Task<IActionResult> GetAppointments([FromQuery] int patientId)
    {
        var command = new GetAppointmentsQuery(patientId);
        var result = await _sender.Send(command);

        return Ok(result);
    }
}