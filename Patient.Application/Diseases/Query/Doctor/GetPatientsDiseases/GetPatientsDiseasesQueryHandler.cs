using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Application.Users;
using Patient.Domain.Repositories;
using Shared.Dtos;

namespace Patient.Application.Diseases.Query.Doctor.GetPatientsDiseases;

internal class GetPatientsDiseasesQueryHandler(ILogger<GetPatientsDiseasesQuery> logger,
UserManager<Domain.Entities.Actors.Doctor> patientManager,
IUserContext userContext,
IDiseaseRepository diseaseRepository, IMapper mapper) : IRequestHandler<GetPatientsDiseasesQuery, List<PatientsDiseaseDto>>
{
    public async Task<List<PatientsDiseaseDto>> Handle(GetPatientsDiseasesQuery request, CancellationToken cancellationToken)
    {
        var user = await userContext.GetCurrentUserAsync();
        logger.LogInformation($"Getting diseases for doctor id: {user.Id}");

        var patientsDiseases = await diseaseRepository.GetPatientsDiseases(request.PatientId, cancellationToken);
        List<PatientsDiseaseDto> patientsDiseasesDtos = new();
        foreach (var item in patientsDiseases)
        {

            var dto = new PatientsDiseaseDto()
            {
                IdToDistinction = patientsDiseasesDtos.Count() + 1,
                Disease = await diseaseRepository.GetDiseaseByIdAsync(item.Id, cancellationToken),
                UserExperienceWithDisease = item.UserExperienceWithDisease,
                IsCurrentlyTreated = item.IsCurrentlyTreated,
            };
            patientsDiseasesDtos.Add(dto);
        }

        return patientsDiseasesDtos;
    }
}
