using Patient.Domain.Entities.Actors;

namespace Patient.Domain.Entities;

public class PrescriptionRequest
{
    public int Id { get; set; }
    public List<string> MedicineNames { get; set; } = new();
    public string Description { get; set; } = default!;
    public DateOnly DateOfIssue { get; set; }
    public bool IsIssued { get; set; }


    //
    public string PatientId { get; set; } = default!;
    public string DoctorId { get; set; } = default!;

}
