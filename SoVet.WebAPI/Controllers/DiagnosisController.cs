using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Commands.Appointment;
using SoVet.Domain.Commands.Diagnosis;
using SoVet.Domain.Models;

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
}