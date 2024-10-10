using MediatR;
using Microsoft.AspNetCore.Mvc;
using Patient.Application.Prescriptions.Queries.Patient.GetPatientPrescriptions;
using Patient.Domain.Entities.DTOs.Recommandation;
using Patient.Application.Prescriptions.Commands.Patient.AskForPrescription;
using Patient.Domain.Entities.DTOs.PrescriptionRequest;

namespace Patient.Api.Controllers;



[ApiController]
[Route("/api/PrescriptionController")]
public class PrescriptionController(IMediator mediator, ILogger<PrescriptionController> logger) : ControllerBase
{
    
}
