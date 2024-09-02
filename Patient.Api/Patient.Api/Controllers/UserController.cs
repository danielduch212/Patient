using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Patient.Api.Client.AdditionalClasses;
using Patient.Application.Users.Commands.Patients.LogIn;
using Patient.Application.Users.Commands.Patients.Register;
using Patient.Domain.Entities.Additional;
using Shared.Identity;

namespace Patient.Api.Controllers;

[ApiController]
[Route("/api/Users")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterPatientCommand command)
    {
        var result = await mediator.Send(command);
        IdentityOperationResult _operationResult = new IdentityOperationResult();
        if (result!=null)
        {            
            _operationResult.IsSuccess = result.Succeeded;
            _operationResult.Errors = result.Errors.Select(e => e.Description.ToString()).ToList();
        }
        return Ok(_operationResult);
    }
    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginPatientCommand command)
    {
        var result = await mediator.Send(command);
        IdentityOperationResult _operationResult = new IdentityOperationResult();
        if (result != null)
        {
            _operationResult.IsSuccess = result.Succeeded;
            
        }
        return Ok(_operationResult);
    }
}
