using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Application.Prescriptions.Queries.Patient.GetPatientPrescriptions;
using Patient.Application.Users;
using Patient.Domain.Entities;
using Patient.Domain.Entities.DTOs.Prescription;
using Patient.Domain.Entities.DTOs.PrescriptionRequest;
using Patient.Domain.Repositories;

namespace Patient.Application.PrescriptionRequests.Queries.Doctor.GetDoctorsPrescriptionRequests;

internal class GetDoctorsPrescriptionRequestsQueryHandler(ILogger<GetDoctorsPrescriptionRequestsQuery> logger,
    IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Doctor> doctorManager,
    UserManager<Domain.Entities.Actors.Patient> patientManager, IUserContext userContext,
    HttpClient _httpClient,
    IPrescriptionRequestRepository prescriptionRepository) : IRequestHandler<GetDoctorsPrescriptionRequestsQuery, List<PrescriptionRequestToShowToDoctorDto>>
{
    public async Task<List<PrescriptionRequestToShowToDoctorDto>> Handle(GetDoctorsPrescriptionRequestsQuery request, CancellationToken cancellationToken)
    {
        var userDoctor = userContext.GetCurrentUser();
        logger.LogInformation($"Getting prescription requests for doctor user: {userDoctor.Email}");

        var doctor = await doctorManager.FindByEmailAsync(userDoctor.Email);

        var prescriptionRequests = await prescriptionRepository.GetDoctorsPrescriptionRequests(doctor.Id, cancellationToken);

        List<PrescriptionRequestToShowToDoctorDto> dtos = new();

        foreach(var item in prescriptionRequests)
        {
            var currentPatientForRequest = await patientManager.FindByIdAsync(item.PatientId);
            var dto = new PrescriptionRequestToShowToDoctorDto()
            {
                PrescriptionRequestId = item.Id,
                MedicineNames = item.MedicineNames,
                Description = item.Description,
                DateOfIssue = item.DateOfIssue.ToString(),
                
                PatientId = item.PatientId,
                PatientName = currentPatientForRequest.Name,
                PatientSurname = currentPatientForRequest.Surname,
                PatientPesel = currentPatientForRequest.Pesel,
            };
            dtos.Add(dto);
        }

        return dtos;
        
    }
    
}
