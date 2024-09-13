namespace Patient.Domain.Entities.DTOs;

public class MedicalFileDto
{
    public string? Description { get; set; }
    public string MedicalDocumentationType { get; set; } = default!;
    public Stream File { get; set; }
    public string? FileName { get; set; }


    
}
