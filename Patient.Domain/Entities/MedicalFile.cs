namespace Patient.Domain.Entities;

public class MedicalFile
{
    public int  Id { get; set; } 
    public string Name { get; set; } = default!;
    public string? Description { get; set; } 
    public string? FileName {  get; set; } 

    
    //
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = default!;

}
