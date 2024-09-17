using Patient.Domain.Entities.Actors;
namespace Patient.Domain.Entities;


public class MedicalFile
{
    public int  Id { get; set; }
    public string MedicalDocumentationType { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string FileUrl { get; set; } = default!;
    public string FileName { get; set; } = default!;


    //
    public string PatientId { get; set; } = default!;
    public Patient.Domain.Entities.Actors.Patient Patient { get; set; } = default!;

}
