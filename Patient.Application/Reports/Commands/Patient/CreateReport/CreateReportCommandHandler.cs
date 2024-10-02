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

namespace Patient.Application.Reports.Commands.Patient.CreateReport;

internal class CreateReportCommandHandler(ILogger<CreateReportCommandHandler> logger,
    IdentityUserAccessor userAccessor, IHttpContextAccessor httpContextAccesor, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IReportRepository reportRepository, IDoctorsRepository doctorsRepository) : IRequestHandler<CreateReportCommand, int>
{
    public async Task<int> Handle(CreateReportCommand request, CancellationToken cancellationToken)
    {
        var user = await userAccessor.GetRequiredUserAsync(httpContextAccesor.HttpContext);
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
        var doctor = await doctorsRepository.AssignAvailibleDoctor();
        doctorsToCheck.Add(doctor);
        Report report = new()
        {
            Description = request.Description,
            FileNames = fileNames,
            PatientId = user.Id,
            DateOfCreating = DateTime.Today.ToString("yyyy-MM-dd"),
            DoctorsToCheck = doctorsToCheck,
            HealthRating = 2,
        };

        await reportRepository.CreateReport(report);
        logger.LogInformation($"Created report with given id: {report.Id}");
        return report.Id;

    }


}
