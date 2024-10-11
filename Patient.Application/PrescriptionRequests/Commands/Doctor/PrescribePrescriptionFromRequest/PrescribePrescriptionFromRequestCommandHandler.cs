using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Application.Users;
using Patient.Domain.Entities;
using Patient.Domain.Repositories;

namespace Patient.Application.PrescriptionRequests.Commands.Doctor.PrescribePrescriptionFromRequest;

internal class PrescribePrescriptionFromRequestCommandHandler(ILogger<PrescribePrescriptionFromRequestCommandHandler> logger,
IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Patient> patientManager,
IUserContext userContext, HttpClient _httpClient,
IPrescriptionRequestRepository prescriptionRequestRepository,
IDoctorsRepository doctorsRepository,
IPrescriptionRepository prescriptionRepository) : IRequestHandler<PrescribePrescriptionFromRequestCommand, bool>
{
    public async Task<bool> Handle(PrescribePrescriptionFromRequestCommand request, CancellationToken cancellationToken)
    {
        var userDoctor = await userContext.GetCurrentUserAsync();
        logger.LogInformation($"Prescripting medicines by doctor user: {userDoctor.Id}");

        await prescriptionRequestRepository.MarkPresriptionRequestAsIssued(request.Dto.PrescriptionRequestId, cancellationToken);
        Prescription prescription = new()
        {
            MedicineNames = request.Dto.MedicineNames,
            Description = request.Dto.Description,
            DateOfIssue = DateOnly.FromDateTime(DateTime.Today),
            DateOfExpiration = DateOnly.FromDateTime(DateTime.Today).AddDays(30),
            PatientId = request.Dto.PatientId,
            DoctorId = userDoctor.Id,
        };
        await prescriptionRepository.AddPrescriptionAsync(prescription, cancellationToken);
        logger.LogInformation($"Added prescription id: {prescription.Id}");
        return true;
    }

}
