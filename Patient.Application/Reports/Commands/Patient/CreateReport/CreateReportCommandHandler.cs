using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Patient.Domain.Interfaces;
using Patient.Domain.Repositories;
using Patient.Application.Account;
using AutoMapper;
using Patient.Domain.Entities;
using Patient.Domain.Constants;
using Patient.Domain.Entities.Actors;
using Patient.Application.Users;

namespace Patient.Application.Reports.Commands.Patient.CreateReport;

internal class CreateReportCommandHandler(ILogger<CreateReportCommandHandler> logger,
    IdentityUserAccessor userAccessor, IUserContext userContext, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IReportRepository reportRepository, IDoctorsRepository doctorsRepository) : IRequestHandler<CreateReportCommand, int>
{
    public async Task<int> Handle(CreateReportCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation($"Trying to add report from user(email): {user.Email}");

        List<string> fileNames = new();
        if (request.Files.Any())
        {
            foreach (var file in request.Files)
            {
                var stream = file.OpenReadStream();
                fileNames.Add(await blobStorageService.UploadReportsFilesToBob(stream, file.FileName, user.Id));
            }
        }
        List<Doctor> doctorsToCheck = new List<Doctor>();

        //sprawdzenie
        var patientsDoctorFirstContact = await doctorsRepository.GetPatientsFirstContactDoctor(user.Id, cancellationToken);
        if(patientsDoctorFirstContact == null)
        {
            await doctorsRepository.AssignFirstContactDoctorToPatient(user.Id, cancellationToken);
            patientsDoctorFirstContact = await doctorsRepository.GetPatientsFirstContactDoctor(user.Id, cancellationToken);
        }
        doctorsToCheck.Add(patientsDoctorFirstContact);
        
        Report report = new()
        {
            AdditionalDescription = request.Description,
            FileNames = fileNames,
            PatientId = user.Id,
            DateOfCreating = DateTime.Today.ToString("yyyy-MM-dd"),
            DoctorsToCheck = doctorsToCheck,
            PatientsHealthRating = 2,
            PatientsSymptoms = request.PatientsSymptoms,
            PatientsAnswersForQuestions = request.PatientsAnswers,

        };

        await reportRepository.CreateReport(report, cancellationToken);
        logger.LogInformation($"Created report with given id: {report.Id}");
        return report.Id;

    }


}
