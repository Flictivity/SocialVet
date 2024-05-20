using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Commands.Appointment;
using SoVet.Domain.Models;
using SoVet.Domain.Queries.Appointment;
using SoVet.Domain.Queries.Diagnosis;
using SoVet.Domain.Queries.Facility;

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
    
    [HttpGet("diagnoses")]
    public async Task<IActionResult> GetAppointmentDiagnoses([FromQuery] int appointmentId)
    {
        var command = new GetAppointmentDiagnosesQuery(appointmentId);
        var result = await _sender.Send(command);

        return Ok(result);
    }
    
    [HttpGet("facilities")]
    public async Task<IActionResult> GetFacilitiesInAppointment([FromQuery] int appointmentId)
    {
        var command = new GetFacilitiesInAppointmentQuery(appointmentId);
        var result = await _sender.Send(command);
        return Ok(result);
    }

    [HttpPost("save")]
    public async Task<IActionResult> SaveAppointment([FromBody] Appointment appointment)
    {
        var command = new SaveAppointmentCommand(appointment);
        var result = await _sender.Send(command);

        return Ok(result);
    }
    
    [HttpGet("registration")]
    public async Task<IActionResult> CheckAppointmentExist([FromQuery] int registrationId)
    {
        var command = new GetAppointmentByRegistrationCommand(registrationId);
        var result = await _sender.Send(command);

        return Ok(result);
    }
}