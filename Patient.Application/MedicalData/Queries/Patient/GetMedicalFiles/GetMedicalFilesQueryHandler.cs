using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Domain.Interfaces;
using Patient.Domain.Repositories;
using Patient.Domain.Constants;
using Patient.Domain.Entities.DTOs.MedicalFiles;
using Patient.Application.Users;

namespace Patient.Application.MedicalData.Queries.Patient.GetMedicalFiles;

internal class GetMedicalFilesQueryHandler(ILogger<GetMedicalFilesQueryHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Patient> patientManager,
    IUserContext userContext, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IMedicalDataRepository medicalDataRepository) : IRequestHandler<GetMedicalFilesQuery, List<MedicalFileToShowDto>>
{
    public async Task<List<MedicalFileToShowDto>> Handle(GetMedicalFilesQuery request, CancellationToken cancellationToken)
    {
        var user = await userContext.GetCurrentUserAsync();
        var patient = await patientManager.FindByEmailAsync(user.Email);
        logger.LogInformation($"Getting medical files for user: {user.Email}");

        var medicalFiles = await medicalDataRepository.GetPatientFiles(patient, cancellationToken);

        List<MedicalFileToShowDto> medicalFilesToShowDto = new List<MedicalFileToShowDto>();
        if (medicalFiles.Any())
        {

            foreach (var file in medicalFiles)
            {
                var sasUrl = await blobStorageService.GetBlobSasUrl(file.FileUrl, BlobContainerNames.MedicalData);

                var medicalFile = new MedicalFileToShowDto()
                {
                    MedicalDocumentationType = file.MedicalDocumentationType,
                    Description = file.Description,
                    FileUrl = sasUrl,
                    FileName = file.FileName,
                };
                medicalFilesToShowDto.Add(medicalFile);
            }
        }
        logger.LogInformation($"Returning to user: {patient.Email}  : {medicalFilesToShowDto.Count} files");
        return medicalFilesToShowDto;

    }
}
