namespace Patient.Domain.Entities.DTOs.PrescriptionRequest;

public class PrescriptionRequestToShowToDoctorDto
{
    public int PrescriptionRequestId { get; set; }
    public List<string> MedicineNames { get; set; } = new();
    public string Description { get; set; } = default!;
    public string DateOfIssue { get; set; } = default!;

    //
    public string PatientId { get; set; } = default!;
    public string PatientName { get; set; } = default!;
    public string PatientSurname { get; set; } = default!;
    public string PatientPesel { get; set; } = default!;


}
