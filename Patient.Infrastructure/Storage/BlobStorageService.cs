using Microsoft.Extensions.Options;
using Patient.Infrastructure.Configuration;
using Patient.Domain.Interfaces;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Patient.Domain.Constants;

namespace Patient.Infrastructure.Storage;

public class BlobStorageService(IOptions<BlobStorageSettings> blobStorageSettingsOption) : IBlobStorageService
{
    private readonly BlobStorageSettings _blobStorageSettings = blobStorageSettingsOption.Value;

    public async Task<string> UploadMedicalDataToBlob(Stream data, string filename)
    {
        var blobServiceClient = new BlobServiceClient(_blobStorageSettings.ConnectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(_blobStorageSettings.MedicalDataContainerName);

        var blobClient = containerClient.GetBlobClient(filename);

        await blobClient.UploadAsync(data);

        var blobUrl = blobClient.Uri.ToString();
        return blobUrl;
    }

    public async Task<string> UploadReportsFilesToBob(Stream data, string filename)
    {
        var blobServiceClient = new BlobServiceClient(_blobStorageSettings.ConnectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(_blobStorageSettings.ReportsFilesContainerName);
        var blobClient = containerClient.GetBlobClient(filename);

        await blobClient.UploadAsync(data);

        var blobUrl = blobClient.Uri.ToString();
        return blobUrl;
    }

    public async Task<string>? GetBlobSasUrl(string? blobUrl, string blobContainerName)
    {
        if (blobUrl == null) return null;

        var sasBuilder = new BlobSasBuilder()
        {    
            BlobContainerName = blobContainerName,
            Resource = "b",
            StartsOn = DateTime.UtcNow,
            ExpiresOn = DateTime.UtcNow.AddMinutes(30),
            BlobName = GetBlobNameFromUrl(blobUrl),

        };
        sasBuilder.SetPermissions(BlobSasPermissions.Read);
        //tutaj mozna to potem dopracowac dla usera i dla pacjenta - pacjent moze usuwac, lekarz nie

        var blobServiceClient = new BlobServiceClient(_blobStorageSettings.ConnectionString);

        var sasToken = sasBuilder
            .ToSasQueryParameters(new Azure.Storage.StorageSharedKeyCredential(blobServiceClient.AccountName, _blobStorageSettings.AccountKey))
            .ToString();
        return $"{blobUrl}?{sasToken}";

    }

    private string GetBlobNameFromUrl(string blobUrl)
    {
        var uri = new Uri(blobUrl);
        return uri.Segments.Last();
    }

}
