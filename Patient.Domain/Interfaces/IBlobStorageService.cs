namespace Patient.Domain.Interfaces;

public interface IBlobStorageService
{
    public Task<string> UploadMedicalDataToBlob(Stream data, string filename);
    public Task<string> UploadReportsFilesToBob(Stream data, string filename);
    public Task<string>? GetBlobSasUrl(string? blobUrl, string blobContainerName);



}
