using MediatR;
using Microsoft.AspNetCore.Mvc;
using Patient.Application.Diseases.Command.Patient.AddPatientsDiseases;
using Patient.Application.Diseases.Query.GetPatientsDiseases;
using Patient.Application.Prescriptions.Commands.Patient.AskForPrescription;
using Patient.Domain.Repositories;
using Shared.Dtos;



namespace Patient.Api.Controllers;

[ApiController]
[Route("/api/DiseaseController")]
public class DiseaseController(IMediator mediator, ILogger<DiseaseController> logger,
    IDiseaseRepository _diseaseRepository) : ControllerBase
{
    [HttpGet("getDiseasesNamesBySearchPhrase")]
    public async Task<IActionResult> GetMedicineNamesBySearchPhrase([FromQuery] string searchPhrase)
    {
        //uproszona funkcja - nie ma sensu robic command
        var diseases = await _diseaseRepository.SearchDiseases(searchPhrase);
        return Ok(diseases);
    }
    [HttpPost("addPatientsDiseases")]
    public async Task<IActionResult> AddPatientsDiseases([FromBody] List<PatientsDiseaseDto> dtos)
    {
        var command = new AddPatientsDiseasesCommand()
        {
            Dtos = dtos,
        };

        var response = await mediator.Send(command);
        if (response)
            return Ok(response);
        
        return BadRequest();
    }
    [HttpGet("getPatientsDiseases")]
    public async Task<IActionResult> GetPatientsDiseases()
    {
        var results = await mediator.Send(new GetPatientsDiseasesQuery());
        return Ok(results);
    }

}

