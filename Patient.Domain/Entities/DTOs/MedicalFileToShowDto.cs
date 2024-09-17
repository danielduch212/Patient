namespace Patient.Domain.Entities.DTOs;

public class MedicalFileToShowDto
{
    public string MedicalDocumentationType { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string FileUrl { get; set; } = default!;
    public string FileName { get; set; } = default!;
    public string? FileBase64 {get;set;} = default!;
}
