using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Commands.Appointment;
using SoVet.Domain.Commands.Diagnosis;
using SoVet.Domain.Models;
using SoVet.Domain.Queries.Diagnosis;

namespace SoVet.WebAPI.Controllers;

public sealed class DiagnosisController : AuthorizedControllerBase
{
    private readonly ISender _sender;

    public DiagnosisController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost("save")]
    public async Task<IActionResult> SaveDiagnosis([FromBody] Diagnosis diagnosis)
    {
        var command = new SaveDiagnosisCommand(diagnosis);
        var result = await _sender.Send(command);

        return Ok(result);
    }
    
    [HttpPut("delete")]
    public async Task<IActionResult> DeleteDiagnosis([FromBody] int diagnosisId)
    {
        var command = new DeleteDiagnosisCommand(diagnosisId);
        var result = await _sender.Send(command);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetDiagnoses()
    {
        var command = new GetDiagnosesQuery();
        var result = await _sender.Send(command);

        return Ok(result);
    }
    
    [HttpPost("save-in-appointment")]
    public async Task<IActionResult> SaveDiagnosisInAppointment([FromBody] AppointmentDiagnoses appointmentDiagnoses)
    {
        var command = new SaveDiagnosisInAppointmentCommand(appointmentDiagnoses);
        var result = await _sender.Send(command);
        return Ok(result);
    }
    
    [HttpPut("delete-in-appointment")]
    public async Task<IActionResult> DeleteDiagnosisInAppointment([FromBody] int appointmentDiagnosisId)
    {
        var command = new DeleteDiagnosisInAppointmentCommand(appointmentDiagnosisId);
        var result = await _sender.Send(command);
        return Ok(result);
    }
}