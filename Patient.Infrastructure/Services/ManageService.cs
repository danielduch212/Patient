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
}
