using Patient.Domain.Entities;

namespace Patient.Domain.Entities.DTOs.Recommandation;

public class MedicalRecommandationDto
{
    public string Description { get; set; } = default!;
    public DateOnly DateOfIssue { get; set; } 
    public Patient.Domain.Entities.Prescription? Prescription { get; set; }


    //
    public string PatientId { get; set; } = default!;
    public string DoctorId { get; set; } = default!;
    
}
