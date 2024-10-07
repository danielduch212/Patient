using MediatR;
using Microsoft.AspNetCore.Mvc;
using Patient.Application.Diseases.Command.Patient.AddPatientsDiseases;
using Patient.Application.Diseases.Query.GetPatientsDiseases;
using Patient.Application.PrescriptionRequests.Commands.Doctor.PrescribePrescriptionFromRequest;
using Patient.Application.PrescriptionRequests.Queries.Doctor.GetDoctorsPrescriptionRequests;
using Patient.Application.Prescriptions.Commands.Patient.AskForPrescription;
using Patient.Domain.Entities.DTOs.PrescriptionRequest;
using Patient.Domain.Repositories;
using Shared.Dtos;



namespace Patient.Api.Controllers;

[ApiController]
[Route("/api/PrescriptionRequestController")]
public class PrescriptionRequestController(IMediator mediator, ILogger<PrescriptionRequestController> logger) : ControllerBase
{
    
    [HttpGet("getDoctorsPrescriptionRequests")]
    public async Task<IActionResult> GetPatientsDiseases()
    {
        var results = await mediator.Send(new GetDoctorsPrescriptionRequestsQuery());
        return Ok(results);
    }

    [HttpPost("prescribePrescriptionFromRequest")]
    public async Task<IActionResult> PrescribePrescriptionFromRequest([FromBody] PrescriptionRequestToShowToDoctorDto dto)
    {
        var command = new PrescribePrescriptionFromRequestCommand()
        {
            Dto = dto,
        };

        var response = await mediator.Send(command);
        if (response)
            return Ok(response);

        return BadRequest();
    }
}

