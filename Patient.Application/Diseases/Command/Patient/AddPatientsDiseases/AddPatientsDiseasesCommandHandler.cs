using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Application.Users;
using Patient.Domain.Entities;
using Patient.Domain.Repositories;
using Shared.Main;

namespace Patient.Application.Diseases.Command.Patient.AddPatientsDiseases;

internal class AddPatientsDiseasesCommandHandler(ILogger<AddPatientsDiseasesCommandHandler> logger,
IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Patient> patientManager,
IUserContext userContext,
IDiseaseRepository diseaseRepository,
IDoctorsRepository doctorsRepository) : IRequestHandler<AddPatientsDiseasesCommand, bool>
{
    public async Task<bool> Handle(AddPatientsDiseasesCommand request, CancellationToken cancellationToken)
    {
        //tutaj tylko dodaje nowe choroby - do usuwania starych bedzie inny command zeby nie utrudniac
        var user = userContext.GetCurrentUser();
        logger.LogInformation($"Adding diseases for patient id: {user.Id}");

        List<PatientsDisease> patientsDiseases = new List<PatientsDisease>();
        foreach(var item in request.Dtos)
        {
            var patientDisease = new PatientsDisease()
            {
                DiseaseId = item.Disease.Id,
                UserExperienceWithDisease = item.UserExperienceWithDisease,
                IsCurrentlyTreated = item.IsCurrentlyTreated,
                PatientId = user.Id,
            };
            patientsDiseases.Add(patientDisease);
        }

        await diseaseRepository.AddPatientsDiseases(patientsDiseases, cancellationToken);
        var patientsDoctor = await doctorsRepository.GetPatientsFirstContactDoctor(user.Id, cancellationToken);
        if (patientsDoctor == null)
        {
            await doctorsRepository.AssignFirstContactDoctorToPatient(user.Id, cancellationToken);
            logger.LogInformation($"Assigning first contact doctor for patient: {user.Id}");

        }
        return true;
    }
    
}
