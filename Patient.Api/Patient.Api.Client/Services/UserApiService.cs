using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Shared.AdditionalClasses;
using Shared.Dtos;


namespace Patient.Api.Client.Services;

public class UserApiService
{
    private readonly HttpClient _httpClient;

    public UserApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
   
    
    public async Task<HttpResponseMessage> SendAddReportRequest(ReportDtoFront report)
    {
        var form = new MultipartFormDataContent();
        form.Add(new StringContent(report.Description), "Description");
        form.Add(new StringContent(report.PatientsHealthRating.ToString()), "PatientsHealthRating");
        foreach (var symptom in report.PatientsSymptoms)
        {
            form.Add(new StringContent(symptom), "PatientsSymptoms");
        }
        foreach (var answer in report.PatientsAnswers)
        {
            form.Add(new StringContent(answer), "PatientsAnswers");
        }
        if (report.Files != null && report.Files.Any() && report.FileNames != null)
        {
            for (int i = 0; i < report.Files.Count(); i++)
            {
                var fileContent = new StreamContent(report.Files.ElementAt(i));
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                form.Add(fileContent, "Files", report.FileNames.ElementAt(i));
            }
        }
        var response = await _httpClient.PostAsync("/api/ReportsController/createReport", form);
        return response;
    }
    public async Task<HttpResponseMessage> SendRequestSearchDiseases(string searchPhrase)
    {
        var url = $"/api/DiseaseController/getDiseasesNamesBySearchPhrase?searchPhrase={Uri.EscapeDataString(searchPhrase)}";
        var response = await _httpClient.GetAsync(url);
        return response;
    }
    public async Task<HttpResponseMessage> SendRequestAddPatientsDiseases(List<PatientsDiseaseDto> dtos)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/DiseaseController/addPatientsDiseases", dtos);
        return response;
    }   
    public async Task<HttpResponseMessage> SendRequestGetPatientsDiseases()
    {
        var response = await _httpClient.GetAsync("/api/DiseaseController/getPatientsDiseases");
        return response;
    }
}
