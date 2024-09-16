using Microsoft.AspNetCore.Http;
using Patient.Domain.Entities.DTOs;
using Patient.Domain.Interfaces;
using Shared.AdditionalClasses;

namespace Patient.Infrastructure.Services;

internal class PatientApiService : IPatientApiService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PatientApiService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task<HttpResponseMessage> SendRequestAddMedicalFiles(List<MedicalFileDto> medicalFileDtos)
    {
        var form = new MultipartFormDataContent();


        if (medicalFileDtos.Any())
        {
            foreach (var medicalFileDto in medicalFileDtos)
            {
                var description = new StringContent(medicalFileDto.Description);
                form.Add(description, "Description");
                var medicalDocumentationType = new StringContent(medicalFileDto.MedicalDocumentationType);
                form.Add(medicalDocumentationType, "MedicalDocumentationType");

                var fileContent = new StreamContent(medicalFileDto.File);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                form.Add(fileContent, "File", medicalFileDto.FileName);
            }
        }

        var cookies = _httpContextAccessor.HttpContext.Request.Headers["Cookie"].ToString();

        _httpClient.DefaultRequestHeaders.Add("Cookie", cookies);

        var response = await _httpClient.PostAsync("/api/MedicalDataController/addMedicalData", form);
        return response;
    }
}
