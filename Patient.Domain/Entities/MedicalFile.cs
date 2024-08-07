using Patient.Domain.Entities.Actors;
namespace Patient.Domain.Entities;


public class MedicalFile
{
    public int  Id { get; set; } 
    public string Name { get; set; } = default!;
    public string? Description { get; set; } 
    public string? FileName {  get; set; } 

    
    //
    public string PatientId { get; set; } = default!;
    public Patient.Domain.Entities.Actors.Patient Patient { get; set; } = default!;

}
