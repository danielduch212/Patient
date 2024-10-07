using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Domain.Repositories;
using Patient.Domain.Entities;

namespace Patient.Application.PrescriptionRequests.Commands.Doctor.PrescribePrescriptionFromRequest;

internal class PrescribePrescriptionFromRequestCommandHandler(ILogger<PrescribePrescriptionFromRequestCommandHandler> logger,
IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Patient> patientManager,
IHttpContextAccessor httpContextAccesor, HttpClient _httpClient,
IPrescriptionRequestRepository prescriptionRequestRepository,
IDoctorsRepository doctorsRepository,
IPrescriptionRepository prescriptionRepository) : IRequestHandler<PrescribePrescriptionFromRequestCommand, bool>
{
    public async Task<bool> Handle(PrescribePrescriptionFromRequestCommand request, CancellationToken cancellationToken)
    {
        var userDoctor = await userAccessor.GetRequiredUserAsync(httpContextAccesor.HttpContext);
        logger.LogInformation($"Prescripting medicines by doctor user: {userDoctor.Id}");

        await prescriptionRequestRepository.MarkPresriptionRequestAsIssued(request.Dto.PrescriptionRequestId);
        Prescription prescription = new()
        {
            MedicineNames = request.Dto.MedicineNames,
            Description = request.Dto.Description,
            DateOfIssue = DateOnly.FromDateTime(DateTime.Today),
            DateOfExpiration = DateOnly.FromDateTime(DateTime.Today).AddDays(30),
            PatientId = request.Dto.PatientId,
            DoctorId = userDoctor.Id,
        };
        await prescriptionRepository.AddPrescriptionAsync(prescription);
        logger.LogInformation($"Added prescription id: {prescription.Id}");
        return true;
    }

}
