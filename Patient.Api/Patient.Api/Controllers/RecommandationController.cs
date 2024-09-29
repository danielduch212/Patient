using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patient.Application.Recommandation.Commands.Doctor.CreateRecommandation;
using Patient.Domain.Constants;
using Patient.Domain.Entities.DTOs.Recommandation;

namespace Patient.Api.Controllers;


[ApiController]
[Route("/api/RecommandationController")]
public class RecommandationController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = UserRoles.Doctor)]
    [HttpPost("createRecommandation")]
    public async Task<IActionResult> CreateRecommandation([FromBody] MedicalRecommandationDto dto)
    {
        var command = new CreateRecommandationCommand
        {
            MedicalRecommandationDto = dto,
        };

        var response = await mediator.Send(command);
        if (response)
            return Ok(response);
        
        return BadRequest();
    }
}
