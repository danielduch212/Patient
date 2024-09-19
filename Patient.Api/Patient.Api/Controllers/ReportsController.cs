using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patient.Application.MedicalData.Queries.GetMedicalFiles;
using Patient.Application.Reports.Commands.CreateReport;
using Patient.Application.Reports.Queries.GetReport;
using Patient.Application.Reports.Queries.GetReports;
using Patient.Domain.Constants;

namespace Patient.Server.Controllers;



[ApiController]
[Route("/api/ReportsController")]
public class ReportsController(IMediator mediator, ILogger<ReportsController> logger) : ControllerBase
{
    [Authorize(Roles =UserRoles.Patient)]
    [HttpPost("createReport")]
    public async Task<IActionResult> CreateReport([FromForm] CreateReportCommand command)
    {
        var response = await mediator.Send(command);
        if(response > 0)
        {
            return Ok();
        }
        return BadRequest(response);
    }

    [Authorize(Roles = UserRoles.Patient)]
    [HttpGet("getReports")]
    public async Task<IActionResult> GetReports()
    {
        var result = await mediator.Send(new GetReportsQuery());
        if (result.Count > 0)
        {
            return Ok(result);
        }
        return NoContent();
    }

    [Authorize(Roles = UserRoles.Patient)]
    [HttpGet("getReport")]
    public async Task<IActionResult> GetReport([FromQuery] GetReportQuery query)
    { 
        var result = await mediator.Send(query);
        return Ok(result);
    }

}
