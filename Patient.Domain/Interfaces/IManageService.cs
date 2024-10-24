namespace Patient.Domain.Interfaces;

public interface IManageService
{
    public Task<string> LoadImageBase64(string url);
    public Task<string> GetFileNameFromUrl(string url, string patientId);
}
