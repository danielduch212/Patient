using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Domain.Entities.DTOs;
using Patient.Domain.Interfaces;
using Patient.Domain.Repositories;

namespace Patient.Application.Reports.Queries.GetReports;

internal class GetReportsQueryHandler(ILogger<GetReportsQueryHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Patient.Domain.Entities.Actors.Patient> patientManager,
    IHttpContextAccessor httpContextAccesor, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IReportRepository reportsRepository, IMapper mapper) : IRequestHandler<GetReportsQuery, List<ReportToShowDto>>
{
    public async Task<List<ReportToShowDto>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
    {
        var user = await userAccessor.GetRequiredUserAsync(httpContextAccesor.HttpContext);
        var patient = await patientManager.FindByEmailAsync(user.Email);
        logger.LogInformation($"Getting reports for user: {user.Email}");

        var reports = await reportsRepository.GetPatientReports(patient);

        List<ReportToShowDto> reportsDto = new List<ReportToShowDto>();

        foreach(var report in reports)
        {
            var dto = mapper.Map<ReportToShowDto>(report);
            reportsDto.Add(dto);
        }
      
        logger.LogInformation($"Returning to user: {patient.Email}  : {reportsDto.Count} files");
        return reportsDto;
        
    }
}
