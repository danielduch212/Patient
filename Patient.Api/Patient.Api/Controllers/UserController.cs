using MediatR;
using Microsoft.AspNetCore.Mvc;
using Patient.Application.Users.Commands.Patients.LogIn;
using Patient.Application.Users.Commands.Patients.Register;

namespace Patient.Api.Controllers;

[ApiController]
[Route("/api/Users")]
public class UserController(IMediator mediator, ILogger<UserController> logger) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterPatientCommand command)
    {
        logger.LogInformation("RegisterPatient User endpoint requested");
        var result = await mediator.Send(command);
        
        if (result!=null)
        {
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        return BadRequest(result);


    }
    [HttpPost("loginPatient")]
    public async Task<IActionResult> LoginUser([FromBody] LoginPatientCommand command)
    {
        logger.LogInformation("loginPatient User endpoint requested");
        var result = await mediator.Send(command);
        
        if (result.Length > 0)
        {
            return Ok(result);
            
        }
        return BadRequest();
    }


    
}
