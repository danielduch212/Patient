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
using Patient.Domain.Entities.Additional;

namespace Patient.Application.Reports.Queries.Doctor.GetReport;

internal class GetReportForDoctorQueryHandler(ILogger<GetReportForDoctorQueryHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Doctor> doctorManager,
    IUserContext userContext, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IReportRepository reportsRepository, IMapper mapper,
    IManageService manageService) : IRequestHandler<GetReportForDoctorQuery, ReportForDoctorToShowDto>
{
    public async Task<ReportForDoctorToShowDto> Handle(GetReportForDoctorQuery request, CancellationToken cancellationToken)
    {
        var user = await userContext.GetCurrentUserAsync();
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

        List<FilePreviewData> filesPreviewData = new();
        foreach (var fileUrl in report.FileNames)
        {
            var filePreviewData = new FilePreviewData(){ FileUrl=fileUrl};
            filePreviewData.FileName = await manageService.GetFileNameFromUrl(fileUrl, report.PatientId);
            filesPreviewData.Add(filePreviewData);
        }

        var result = new ReportForDoctorToShowDto()
        {
            Id = report.Id,
            Description = report.AdditionalDescription,
            FilesPreviewData = filesPreviewData,
            IsChecked = report.IsChecked,
            DateOfCreating = report.DateOfCreating,
            Urgency = report.Urgency,
            PatientsHealthRating = report.PatientsHealthRating,
            PatientsAnswersForQuestions = report.PatientsAnswersForQuestions,
            PatientsSymptoms = report.PatientsSymptoms,

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
