using Patient.Domain.Constants;
using Patient.Domain.Entities.Actors;

namespace Patient.Domain.Entities.DTOs.Reports;

public class ReportForDoctorDto
{
    public int Id { get; set; }
    public bool IsChecked { get; set; } = false; // to trzeba przekminic 
    public string DateOfCreating { get; set; } = default!;
    public UrgencyType? Urgency { get; set; }


    public string PatientName { get; set; } = default!;
    public string PatientSurname { get; set; } = default!;
    public string PatientEmail { get; set; } = default!;

}