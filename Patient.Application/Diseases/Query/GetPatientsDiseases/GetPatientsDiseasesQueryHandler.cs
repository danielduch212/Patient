using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Domain.Repositories;
using Shared.Dtos;

namespace Patient.Application.Diseases.Query.GetPatientsDiseases;

internal class GetPatientsDiseasesQueryHandler(ILogger<GetPatientsDiseasesQuery> logger,
IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Patient> patientManager,
IHttpContextAccessor httpContextAccesor,
IDiseaseRepository diseaseRepository, IMapper mapper) : IRequestHandler<GetPatientsDiseasesQuery, List<PatientsDiseaseDto>>
{
    public async Task<List<PatientsDiseaseDto>> Handle(GetPatientsDiseasesQuery request, CancellationToken cancellationToken)
    {
        var user = await userAccessor.GetRequiredUserAsync(httpContextAccesor.HttpContext);
        logger.LogInformation($"Getting diseases for patient id: {user.Id}");

        var patientsDiseases = await diseaseRepository.GetPatientsDiseases(user.Id);
        List<PatientsDiseaseDto> patientsDiseasesDtos = new();
        foreach (var item in patientsDiseases)
        {
            
            var dto = new PatientsDiseaseDto()
            {
                IdToDistinction = patientsDiseasesDtos.Count()+1,
                Disease = await diseaseRepository.GetDiseaseByIdAsync(item.Id),
                UserExperienceWithDisease = item.UserExperienceWithDisease,
                IsCurrentlyTreated = item.IsCurrentlyTreated,
            };
            patientsDiseasesDtos.Add(dto);
        }

        return patientsDiseasesDtos;
    }
}
