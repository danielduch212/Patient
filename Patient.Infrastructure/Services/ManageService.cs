using Patient.Domain.Interfaces;

namespace Patient.Infrastructure.Services;

internal class ManageService : IManageService
{
    public async Task<string> LoadImageBase64(string url)
    {
        using (var _httpClient = new HttpClient())
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var imageBytes = await response.Content.ReadAsByteArrayAsync();
                return $"data:image/jpeg;base64,{Convert.ToBase64String(imageBytes)}";

            };
            return null;
        }

    }

    public async Task<string> GetFileNameFromUrl(string url, string patientId)
    {
        int lastSlashIndex = url.LastIndexOf('/');

        if(lastSlashIndex != -1 && lastSlashIndex + 1 < url.Length)
        {
            string restOfUrl = url.Substring(lastSlashIndex + 1);
            var filename = restOfUrl.Substring(patientId.Length);
            filename = filename.Substring(10);
            return filename; 
        }
        return null;
    }
}
