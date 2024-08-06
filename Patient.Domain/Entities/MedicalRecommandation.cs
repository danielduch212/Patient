namespace Patient.Domain.Entities;

public class MedicalRecommandation
{
    public int Id { get; set; }
    public string Description { get; set; } = default!;
    public DateOnly DateOfIssue { get; set; }
    public Prescription? Prescription { get; set; }
    

    //
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = default!;
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = default!;
}
