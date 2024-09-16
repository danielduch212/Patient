using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Account;
using Patient.Domain.Entities;
using Patient.Domain.Interfaces;
using Patient.Domain.Repositories;


namespace Patient.Application.MedicalData.Commands.AddMedicalFiles;

internal class AddMedicalFilesCommandHandler(ILogger<AddMedicalFilesCommandHandler> logger,
    IdentityUserAccessor userAccessor, UserManager<Patient.Domain.Entities.Actors.Patient> patientManager,
    IHttpContextAccessor httpContextAccesor, HttpClient _httpClient, IBlobStorageService blobStorageService,
    IMedicalDataRepository medicalDataRepository) : IRequestHandler<AddMedicalFilesCommand, bool>
{
    public async Task<bool> Handle(AddMedicalFilesCommand request, CancellationToken cancellationToken)
    {
        
        var user = await userAccessor.GetRequiredUserAsync(httpContextAccesor.HttpContext);
        var patient = await patientManager.FindByEmailAsync(user.Email);

        int previousUserMedicalFilesNumber = 0;

        if (patient.MedicalFiles.Any())
        {
            previousUserMedicalFilesNumber = patient.MedicalFiles.Count();
        }
        

        logger.LogInformation($"Adding medical file(s) to user: {patient.Email}");


        //zakladam ze nie ma sensu wysylac w ogole requesta, ktory nie zawiera plikow - sprawdzenie w api
        foreach (var file in request.medicalFileDtos)
        {
            var fileUrl = await blobStorageService.UploadMedicalDataToBlob(file.File, file.FileName, patient.Id);
            MedicalFile medicalDataFile = new MedicalFile()
            {
                Description = file.Description,
                FileName = fileUrl,
                MedicalDocumentationType = file.MedicalDocumentationType,
                PatientId = patient.Id,                       
            };
            await medicalDataRepository.AddMedicalFile(medicalDataFile);
        }

        if(previousUserMedicalFilesNumber < patient.MedicalFiles.Count())
        {
            logger.LogInformation($"Added files: {request.medicalFileDtos.Count()} to user: {patient.Email}");
            return true;
        }

        logger.LogInformation($"Adding files to user :  {patient.Email} failed.");
        return false;
        
        
    }
}
