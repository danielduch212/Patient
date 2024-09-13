using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Shared.AdditionalClasses;


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


        if (report.Files.Any() && report.FileNames != null)
        {

            for(int i=0; i<report.Files.Count(); i++)
            {
                var fileContent = new StreamContent(report.Files.ElementAt(i));
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                form.Add(fileContent, "Files", report.FileNames.ElementAt(i));
            }
        }


        var response = await _httpClient.PostAsync("/api/Reports/createReport", form);
        return response;
    }

    
}
