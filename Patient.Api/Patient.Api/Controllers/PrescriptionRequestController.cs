using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace Patient.Api.Controllers;

[ApiController]
[Route("/api/PrescriptionRequestController")]
public class PrescriptionRequestController(IMediator mediator, ILogger<PrescriptionRequestController> logger) : ControllerBase
{
    
    
}

