using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patient.Application.Reports.Commands.Patient.CreateReport;
using Patient.Application.Reports.Queries.Doctor.GetReport;
using Patient.Application.Reports.Queries.Doctor.GetReports;
using Patient.Application.Reports.Queries.Patient.GetReport;
using Patient.Application.Reports.Queries.Patient.GetReports;
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

    

}
