using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Application.MedicalData.Queries.Patient.GetMedicalFiles;
using Patient.Application.Users;
using Patient.Domain.Entities.DTOs.Prescription;
using Patient.Domain.Interfaces;
using Patient.Domain.Repositories;

namespace Patient.Application.Prescriptions.Queries.Patient.GetPatientPrescriptions;

internal class GetPatientsPrescriptionsQueryHandler(ILogger<GetPatientsPrescriptionsQueryHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Patient> patientManager,
    IUserContext userContext, HttpClient _httpClient,
    IPrescriptionRepository prescriptionRepository) : IRequestHandler<GetPatientsPrescriptionsQuery, List<PrescriptionToShowPatientDto>>
{
    public async Task<List<PrescriptionToShowPatientDto>> Handle(GetPatientsPrescriptionsQuery request, CancellationToken cancellationToken)
    {

        var user = userContext.GetCurrentUser();
        logger.LogInformation($"Getting prescriptions for patient user: {user.Email}");

        var patient = await patientManager.FindByEmailAsync(user.Email);

        var prescriptions = await prescriptionRepository.GetPatientsPrescriptions(patient.Id);
        List<PrescriptionToShowPatientDto> prescriptionsToShow = new();

        foreach( var prescription in prescriptions)
        {
            var prescriptionToShow = new PrescriptionToShowPatientDto()
            {
                MedicineNames = prescription.MedicineNames,
                Description = prescription.Description,
                DateOfExpiration = prescription.DateOfExpiration.ToString(),
                DateOfIssue = prescription.DateOfIssue.ToString(),
                CodeToGet = CreateRandomCode(),

                PatientsPesel = patient.Pesel,
                DoctorName = prescription.Doctor.Name,
                DoctorSurname = prescription.Doctor.Surname,
            };
            prescriptionsToShow.Add(prescriptionToShow);
        }

        return prescriptionsToShow;
    }

    private string CreateRandomCode()
    {
        Random random = new Random();
        int randomCode = random.Next(1000, 9999);
        return randomCode.ToString();
    }

}
