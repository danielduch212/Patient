using MediatR;
using Microsoft.AspNetCore.Mvc;
using Patient.Application.Prescriptions.Queries.Patient.GetPatientPrescriptions;
using Patient.Domain.Entities.DTOs.Recommandation;
using Patient.Application.Prescriptions.Commands.Patient.AskForPrescription;
using Patient.Domain.Entities.DTOs.PrescriptionRequest;

namespace Patient.Api.Controllers;



[ApiController]
[Route("/api/PrescriptionController")]
public class PrescriptionController(IMediator mediator, ILogger<PrescriptionController> logger) : ControllerBase
{
    [HttpGet("getPatientsPrescriptions")]
    public async Task<IActionResult> GetPatientsPrescriptions()
    {
        var result = await mediator.Send(new GetPatientsPrescriptionsQuery());
        if (result.Count > 0)
        {
            return Ok(result);
        }
        return NoContent();
    }

    [HttpPost("addPrescriptionRequest")]
    public async Task<IActionResult> AddPrescriptionRequest([FromBody] PrescriptionRequestDto dto)
    {
        var command = new AddPrescriptionRequestCommand()
        {
            Dto = dto,
        };

        var response = await mediator.Send(command);
        if (response)
            return Ok(response);

        return BadRequest();
    }
}
