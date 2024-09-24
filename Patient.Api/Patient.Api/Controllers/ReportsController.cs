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

    [Authorize(Roles = UserRoles.Patient)]
    [HttpGet("getReportsForPatient")]
    public async Task<IActionResult> GetReportsForPatient()
    {
        var result = await mediator.Send(new GetReportsForPatientQuery());
        if (result.Count > 0)
        {
            return Ok(result);
        }
        return NoContent();
    }

    [Authorize(Roles = UserRoles.Patient)]
    [HttpGet("getReportForPatient")]
    public async Task<IActionResult> GetReportForPatient([FromQuery] GetReportForPatientQuery query)
    { 
        var result = await mediator.Send(query);
        return Ok(result);
    }

    
    [HttpGet("getReportsForDoctor")]
    public async Task<IActionResult> GetReportsForDoctor()
    {
        var result = await mediator.Send(new GetReportsForDoctorQuery());//
        if (result.Count > 0)
        {
            return Ok(result);
        }
        return NoContent();
    }

    [Authorize(Roles = UserRoles.Doctor)]
    [HttpGet("getReportForDoctor")]
    public async Task<IActionResult> GetReportForDoctor([FromQuery] GetReportForDoctorQuery query)
    {
        var result = await mediator.Send(query);//
        return Ok(result);
    }

}
