using Patient.Domain.Entities.Actors;

namespace Patient.Domain.Entities;

public class MedicalRecommandation
{
    public int Id { get; set; }
    public string Description { get; set; } = default!;
    public DateOnly DateOfIssue { get; set; }
    public Prescription? Prescription { get; set; }
    

    //
    public string PatientId { get; set; } = default!;
    public Patient.Domain.Entities.Actors.Patient Patient { get; set; } = default!;
    public string DoctorId { get; set; } = default!;
    public Doctor Doctor { get; set; } = default!;
}
