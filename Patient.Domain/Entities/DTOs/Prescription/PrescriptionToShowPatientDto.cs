using Patient.Domain.Entities.Actors;

namespace Patient.Domain.Entities.DTOs.Prescription;

public class PrescriptionToShowPatientDto
{
    public List<string> MedicineNames { get; set; } = new();
    //public Decimal? DoseOfMedicine { get; set; }
    public string Description { get; set; } = default!;
    public string DateOfIssue { get; set; } = default!;
    public string DateOfExpiration { get; set; } = default!;

    public string CodeToGet { get; set; } = default!;


    //
    public string PatientsPesel { get; set; } = default!;
    public string DoctorName { get; set; } = default!;
    public string DoctorSurname { get; set; } = default!;
}
