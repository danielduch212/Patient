using Patient.Domain.Entities;

namespace Patient.Domain.Entities.DTOs.Recommandation;

public class MedicalRecommandationDto
{
    public string Description { get; set; } = default!;
    public Patient.Domain.Entities.DTOs.Prescription.PrescriptionDto? Prescription { get; set; }
    public bool AskForVisit { get; set; }
    public bool AskForVisitOnline { get; set; }
    public int? ReportId { get; set; }

    //
    public string PatientId { get; set; } = default!;

    
}
