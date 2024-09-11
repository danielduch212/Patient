﻿namespace Patient.Infrastructure.Configuration;

public class BlobStorageSettings
{
    public string ConnectionString { get; set; } = default!;
    public string MedicalDataContainerName { get; set; } = default!;
    public string ReportsFilesContainerName { get; set; } = default!;
    public string AccountKey { get; set; } = default!;

}
