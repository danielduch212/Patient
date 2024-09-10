using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patient.Domain.Constants;

namespace Patient.Api.Controllers;

[ApiController]
[Route("/api/Users")]
public class UserController(IMediator mediator, ILogger<UserController> logger) : ControllerBase
{
    
    

    

}
