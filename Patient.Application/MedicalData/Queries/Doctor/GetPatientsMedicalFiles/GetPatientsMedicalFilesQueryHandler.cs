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

namespace Patient.Application.MedicalData.Queries.Doctor.GetPatientsMedicalFiles;

internal class GetPatientsMedicalFilesQueryHandler(ILogger<GetPatientsMedicalFilesQueryHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Domain.Entities.Actors.Patient> patientManager,
    IUserContext userContext, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IMedicalDataRepository medicalDataRepository) : IRequestHandler<GetPatientsMedicalFilesQuery, List<MedicalFileToShowDto>>
{
    public async Task<List<MedicalFileToShowDto>> Handle(GetPatientsMedicalFilesQuery request, CancellationToken cancellationToken)
    {
        var user = await userContext.GetCurrentUserAsync();
        
        logger.LogInformation($"Getting medical files for doctor: {user.Email}");

        var medicalFiles = await medicalDataRepository.GetPatientFiles(request.PatientId, cancellationToken);

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
        logger.LogInformation($"Returning to doctor: {user.Email}  : {medicalFilesToShowDto.Count} files");
        return medicalFilesToShowDto;

    }
}
