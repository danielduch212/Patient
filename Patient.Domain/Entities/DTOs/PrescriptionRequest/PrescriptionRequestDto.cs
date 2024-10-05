namespace Patient.Domain.Entities.DTOs.PrescriptionRequest;

public class PrescriptionRequestDto
{
    public List<string> MedicineNames { get; set; } = new();
    //public string Description { get; set; } = default!;

}
