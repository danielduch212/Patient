using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Domain.Interfaces;
using Patient.Domain.Repositories;
using Patient.Domain;
using Patient.Domain.Entities.DTOs.Reports;

namespace Patient.Application.Reports.Queries.Patient.GetReports;

internal class GetReportsForPatientQueryHandler(ILogger<GetReportsForPatientQueryHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Patient> patientManager,
    IHttpContextAccessor httpContextAccesor, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IReportRepository reportsRepository, IMapper mapper) : IRequestHandler<GetReportsForPatientQuery, List<ReportToShowToPatientDto>>
{
    public async Task<List<ReportToShowToPatientDto>> Handle(GetReportsForPatientQuery request, CancellationToken cancellationToken)
    {
        var user = await userAccessor.GetRequiredUserAsync(httpContextAccesor.HttpContext);
        var patient = await patientManager.FindByEmailAsync(user.Email);
        logger.LogInformation($"Getting reports for doctor: {user.Email}");

        var reports = await reportsRepository.GetPatientReports(patient);

        List<ReportToShowToPatientDto> reportsDto = new List<ReportToShowToPatientDto>();

        foreach (var report in reports)
        {
            var dto = mapper.Map<ReportToShowToPatientDto>(report);
            reportsDto.Add(dto);
        }

        logger.LogInformation($"Returning to user: {patient.Email}  : {reportsDto.Count} files");
        return reportsDto;

    }
}
