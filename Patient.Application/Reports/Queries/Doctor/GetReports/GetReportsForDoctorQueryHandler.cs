using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Domain.Entities.DTOs;
using Patient.Domain.Interfaces;
using Patient.Domain.Repositories;
using Patient.Domain;

namespace Patient.Application.Reports.Queries.Doctor.GetReports;

internal class GetReportsForDoctorQueryHandler(ILogger<GetReportsForDoctorQueryHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Doctor> doctorManager,
    IHttpContextAccessor httpContextAccesor, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IReportRepository reportsRepository, IMapper mapper) : IRequestHandler<GetReportsForDoctorQuery, List<ReportToShowToDoctorDto>>
{
    public async Task<List<ReportToShowToDoctorDto>> Handle(GetReportsForDoctorQuery request, CancellationToken cancellationToken)
    {
        var user = await userAccessor.GetRequiredUserAsync(httpContextAccesor.HttpContext);
        var doctor = await doctorManager.FindByEmailAsync(user.Email);
        logger.LogInformation($"Getting reports for doctor: {user.Email}");

        var reports = await reportsRepository.GetDoctorReports(doctor);

        List<ReportToShowToDoctorDto> reportsDto = new List<ReportToShowToDoctorDto>();

        foreach (var report in reports)
        {
            var dto = mapper.Map<ReportToShowToDoctorDto>(report);
            reportsDto.Add(dto);
        }

        logger.LogInformation($"Returning to user: {doctor.Email}  : {reportsDto.Count} files");
        return reportsDto;

    }
}
