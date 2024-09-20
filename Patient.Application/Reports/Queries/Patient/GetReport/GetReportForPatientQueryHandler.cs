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

namespace Patient.Application.Reports.Queries.Patient.GetReport;

internal class GetReportForDoctorQueryHandler(ILogger<GetReportForDoctorQueryHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Patient> patientManager,
    IHttpContextAccessor httpContextAccesor, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IReportRepository reportsRepository, IMapper mapper) : IRequestHandler<GetReportForPatientQuery, ReportToShowToPatientDto>
{
    public async Task<ReportToShowToPatientDto> Handle(GetReportForPatientQuery request, CancellationToken cancellationToken)
    {
        var user = await userAccessor.GetRequiredUserAsync(httpContextAccesor.HttpContext);
        logger.LogInformation($"Getting report for user: {user.Email}");
        var patient = await patientManager.FindByEmailAsync(user.Email);

        var reportId = int.Parse(request.Id);
        var report = await reportsRepository.GetReportForPatient(reportId, patient);


        if (report == null) throw new NotFoundException(nameof(Report), request.Id.ToString());


        var result = mapper.Map<ReportToShowToPatientDto>(report);

        return result;

    }
}
