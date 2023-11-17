using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoVet.Domain.Commands.Patient;
using SoVet.Domain.Models;
using SoVet.Domain.Queries.Patient;
using SoVet.Domain.Responses;

namespace SoVet.WebAPI.Controllers;

public sealed class PatientController : AuthorizedControllerBase
{
    private readonly ISender _sender;

    public PatientController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [Route("patients")]
    public async Task<IActionResult> GetPatients([FromQuery] int? clientId)
    {
        var command = new GetPatientsQuery(clientId);
        var commandResult = await _sender.Send(command);

        return Ok(commandResult);
    }
    
    [HttpGet]
    [Route("patient")]
    public async Task<IActionResult> GetPatient([FromQuery] int patientId)
    {
        var command = new GetPatientQuery(patientId);
        var commandResult = await _sender.Send(command);

        return Ok(commandResult);
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreatePatient([FromBody] Patient patient)
    {
        var command = new CreatePatientCommand(patient);
        var commandResult = await _sender.Send(command);

        if(commandResult.IsSuccess)
            return Ok(new BaseResponse{IsSuccess = true});
        return BadRequest(new BaseResponse{IsSuccess = false});
    }
    
    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdatePatient([FromBody] Patient patient)
    {
        var command = new UpdatePatientCommand(patient);
        var commandResult = await _sender.Send(command);

        if(commandResult.IsSuccess)
            return Ok(new BaseResponse{IsSuccess = true});
        return BadRequest(new BaseResponse{IsSuccess = false});
    }
}