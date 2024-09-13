using MediatR;
using Microsoft.AspNetCore.Mvc;
using Patient.Application.Reports.Commands.CreateReport;

namespace Patient.Api.Controllers;

[ApiController]
[Route("/api/MedicalDataController")]
public class MedicalDataController(IMediator mediator, ILogger<MedicalDataController> logger) : ControllerBase
{

    [HttpPost("addMedicalData")]

    public async Task<IActionResult> AddMedicalData([FromForm] CreateReportCommand command)
    {

    }



}
