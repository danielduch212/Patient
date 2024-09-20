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

namespace Patient.Application.Reports.Queries.Doctor.GetReport;

internal class GetReportForDoctorQueryHandler(ILogger<GetReportForDoctorQueryHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Doctor> doctorManager,
    IHttpContextAccessor httpContextAccesor, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IReportRepository reportsRepository, IMapper mapper) : IRequestHandler<GetReportForDoctorQuery, ReportToShowToDoctorDto>
{
    public async Task<ReportToShowToDoctorDto> Handle(GetReportForDoctorQuery request, CancellationToken cancellationToken)
    {
        var user = await userAccessor.GetRequiredUserAsync(httpContextAccesor.HttpContext);
        logger.LogInformation($"Getting report for user: {user.Email}");
        var doctor = await doctorManager.FindByEmailAsync(user.Email);

        var reportId = int.Parse(request.Id);
        var report = await reportsRepository.GetReportForDoctor(reportId, doctor);


        if (report == null) throw new NotFoundException(nameof(Report), request.Id.ToString());


        var result = mapper.Map<ReportToShowToDoctorDto>(report);

        return result;

    }
}
