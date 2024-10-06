using MediatR;
using Microsoft.AspNetCore.Mvc;
using Patient.Domain.Repositories;



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
    

}
