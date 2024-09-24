using Microsoft.AspNetCore.Http;
using Patient.Domain.Entities;
using Patient.Domain.Interfaces;
using Shared.AdditionalClasses;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using Patient.Domain.Entities.DTOs.MedicalFiles;

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

        AddCookiesToRequest();

        var response = await _httpClient.PostAsync("/api/MedicalDataController/addMedicalData", form);
        return response;
    }

    public async Task<HttpResponseMessage> SendRequestGetMedicalFiles()
    {
        AddCookiesToRequest(); 
        var response = await _httpClient.GetAsync("/api/MedicalDataController/getUserMedicalData");
        return response;
    }

    public async Task<HttpResponseMessage> SendRequestGetReports()
    {
        AddCookiesToRequest();
        var response = await _httpClient.GetAsync("/api/ReportsController/getReportsForPatient");
        return response;
    }

    public async Task<HttpResponseMessage> SendRequestGetReport(string id)
    {
        AddCookiesToRequest();
        var url = $"/api/ReportsController/getReportForPatient?Id={id}";
        var response = await _httpClient.GetAsync(url);
        return response;
    }

    private void AddCookiesToRequest()
    {
        var cookies = _httpContextAccessor.HttpContext.Request.Headers["Cookie"].ToString();
        _httpClient.DefaultRequestHeaders.Add("Cookie", cookies);
    }
}
