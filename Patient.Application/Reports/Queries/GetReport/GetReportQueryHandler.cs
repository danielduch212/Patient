using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Domain.Entities.DTOs;
using Patient.Domain.Interfaces;
using Patient.Domain.Repositories;
using Patient.Domain.Exceptions;
using Patient.Domain.Entities;

namespace Patient.Application.Reports.Queries.GetReport;

internal class GetReportQueryHandler(ILogger<GetReportQueryHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Patient.Domain.Entities.Actors.Patient> patientManager,
    IHttpContextAccessor httpContextAccesor, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IReportRepository reportsRepository, IMapper mapper) : IRequestHandler<GetReportQuery, ReportToShowDto>
{
    public async Task<ReportToShowDto> Handle(GetReportQuery request, CancellationToken cancellationToken)
    {
        var user = await userAccessor.GetRequiredUserAsync(httpContextAccesor.HttpContext);
        logger.LogInformation($"Getting report for user: {user.Email}");

        var reportId = Int32.Parse(request.Id);
        var report = await reportsRepository.GetReport(reportId);

        if (report == null) throw new NotFoundException(nameof(Report), request.Id.ToString());

        var result = mapper.Map<ReportToShowDto>(report);
        
        return result;
        
    }
}
