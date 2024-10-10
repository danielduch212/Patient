using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Domain.Interfaces;
using Patient.Domain.Repositories;
using Patient.Domain.Exceptions;
using Patient.Domain.Entities;
using Patient.Domain.Entities.DTOs.Reports;
using Patient.Domain.Constants;
using Patient.Application.Users;

namespace Patient.Application.Reports.Queries.Doctor.GetReport;

internal class GetReportForDoctorQueryHandler(ILogger<GetReportForDoctorQueryHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Doctor> doctorManager,
    IUserContext userContext, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IReportRepository reportsRepository, IMapper mapper) : IRequestHandler<GetReportForDoctorQuery, ReportForDoctorToShowDto>
{
    public async Task<ReportForDoctorToShowDto> Handle(GetReportForDoctorQuery request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation($"Getting report for user: {user.Email}");
        var doctor = await doctorManager.FindByEmailAsync(user.Email);

        var reportId = int.Parse(request.Id);
        var report = await reportsRepository.GetReportForDoctor(reportId, doctor, cancellationToken);


        if (report == null) throw new NotFoundException(nameof(Report), request.Id.ToString());

        List<string> idDoctorsToCheck = new();
        foreach (var doctorToCheck in report.DoctorsToCheck)
        {
            idDoctorsToCheck.Add(doctorToCheck.Id);
        }

        var result = new ReportForDoctorToShowDto()
        {
            Id = report.Id,
            Description = report.AdditionalDescription,
            FileNames = report.FileNames,
            IsChecked = report.IsChecked,
            DateOfCreating = report.DateOfCreating,
            Urgency = report.Urgency,

            PatientId = report.PatientId,
            PatientName = report.Patient.Name,
            PatientSurname = report.Patient.Surname,
            PatientPesel = report.Patient.Pesel,
            DoctorsId = idDoctorsToCheck,
            MedicalRecommandation = report.MedicalRecommandation,
        };

        return result;

    }
   
}
