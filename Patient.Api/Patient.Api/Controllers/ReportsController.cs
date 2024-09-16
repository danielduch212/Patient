using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patient.Application.Reports.Commands.CreateReport;
using Patient.Domain.Constants;

namespace Patient.Server.Controllers;



[ApiController]
[Route("/api/Reports")]
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
