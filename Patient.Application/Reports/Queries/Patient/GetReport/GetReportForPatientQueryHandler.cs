﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Application.Users;
using Patient.Domain.Entities;
using Patient.Domain.Entities.Additional;
using Patient.Domain.Entities.DTOs.Reports;
using Patient.Domain.Exceptions;
using Patient.Domain.Interfaces;
using Patient.Domain.Repositories;

namespace Patient.Application.Reports.Queries.Patient.GetReport;

internal class GetReportForPatientQueryHandler(ILogger<GetReportForPatientQueryHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Patient> patientManager,
    IUserContext userContext, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IReportRepository reportsRepository, IMapper mapper,
    IManageService manageService) : IRequestHandler<GetReportForPatientQuery, ReportToShowToPatientDto>
{
    public async Task<ReportToShowToPatientDto> Handle(GetReportForPatientQuery request, CancellationToken cancellationToken)
    {
        var user = await userContext.GetCurrentUserAsync();
        logger.LogInformation($"Getting report for user: {user.Email}");
        var patient = await patientManager.FindByEmailAsync(user.Email);

        var reportId = int.Parse(request.Id);
        var report = await reportsRepository.GetReportForPatient(reportId, patient, cancellationToken);


        if (report == null) throw new NotFoundException(nameof(Report), request.Id.ToString());

        List<FilePreviewData> filesPreviewData = new();
        foreach (var fileUrl in report.FileNames)
        {
            var filePreviewData = new FilePreviewData() { FileUrl = fileUrl };
            filePreviewData.FileName = await manageService.GetFileNameFromUrl(fileUrl, patient.Id);
            filesPreviewData.Add(filePreviewData);
        }

        var result = mapper.Map<ReportToShowToPatientDto>(report);
        result.FilesPreviewData = filesPreviewData;
        return result;

    }
}
