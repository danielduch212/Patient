using MediatR;
using Microsoft.AspNetCore.Mvc;
using Patient.Api.Components.Pages.PatientPages.MedicalDocumentation.Additional;
using Patient.Application.MedicalData.Queries.Patient.GetMedicalFiles;
using Patient.Application.MedicalData.Commands.Patient.AddMedicalFiles;
using Patient.Domain.Entities.DTOs.MedicalFiles;

namespace Patient.Api.Controllers;

[ApiController]
[Route("/api/MedicalDataController")]
public class MedicalDataController(IMediator mediator, ILogger<MedicalDataController> logger) : ControllerBase
{

    
    [HttpPost("addMedicalData")]
    public async Task<IActionResult> AddMedicalData()
    {

        var medicalFileDtos = new List<MedicalFileDto>();
        var files = Request.Form.Files;
        var form = Request.Form;


        foreach (var file in files)
        {
            var description = form["Description"];
            var medicalDocType = form["MedicalDocumentationType"];


            var stream = file.OpenReadStream();
                        
            //await file.CopyToAsync(stream);
            var medicalFileDto = new MedicalFileDto()
            {
                Description = description,
                MedicalDocumentationType = medicalDocType,
                File = stream,
                FileName = file.FileName,
            };
            medicalFileDtos.Add(medicalFileDto);
            
        }

        var command = new AddMedicalFilesCommand()
        {
            medicalFileDtos = medicalFileDtos,
        };


        var response = await mediator.Send(command);
        if (response)
            return Ok(response);
        return BadRequest();    
    }

    [HttpGet("getUserMedicalData")]
    public async Task<IActionResult> GetUserMedicalData()
    {
        var result = await mediator.Send(new GetMedicalFilesQuery());
        if (result.Count > 0)
        {
            return Ok(result);
        }
        return NoContent();
    }


}
