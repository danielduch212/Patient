using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Application.Users;
using Patient.Domain.Entities.DTOs.Reports;
using Patient.Domain.Interfaces;
using Patient.Domain.Repositories;

namespace Patient.Application.Reports.Queries.Doctor.GetReports;

internal class GetReportsForDoctorQueryHandler(ILogger<GetReportsForDoctorQueryHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Doctor> doctorManager,
    IUserContext userContext, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IReportRepository reportsRepository, IMapper mapper) : IRequestHandler<GetReportsForDoctorQuery, List<ReportForDoctorDto>>
{
    public async Task<List<ReportForDoctorDto>> Handle(GetReportsForDoctorQuery request, CancellationToken cancellationToken)
    {
        var user = await userContext.GetCurrentUserAsync();
        var doctor = await doctorManager.FindByEmailAsync(user.Email);
        logger.LogInformation($"Getting reports for doctor: {user.Email}");

        var reports = await reportsRepository.GetDoctorReports(doctor, cancellationToken);

        List<ReportForDoctorDto> reportsDto = new List<ReportForDoctorDto>();


        foreach (var report in reports)
        {
            
            var dto = new ReportForDoctorDto()
            {
                Id = report.Id,
                IsChecked = report.IsChecked,
                DateOfCreating = report.DateOfCreating,
                Urgency = report.Urgency,
                
                PatientName = report.Patient.Name,
                PatientSurname = report.Patient.Surname,
                PatientEmail = report.Patient.Email,

            };

            reportsDto.Add(dto);
        }

        logger.LogInformation($"Returning to user: {doctor.Email}  : {reportsDto.Count} files");
        return reportsDto;


    }

}
