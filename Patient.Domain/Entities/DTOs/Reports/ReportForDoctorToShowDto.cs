using Patient.Domain.Constants;
using Patient.Domain.Entities.Actors;

namespace Patient.Domain.Entities.DTOs.Reports;

public class ReportForDoctorToShowDto
{
    public int Id { get; set; }
    public string Description { get; set; } = default!;
    public List<string>? FileNames { get; set; } = new List<string>();
    public bool IsChecked { get; set; } = false;
    public string DateOfCreating { get; set; } = default!;
    public UrgencyType? Urgency { get; set; }
    public List<string>? FilesBase64 { get; set; } = new List<string>();
    public int PatientsHealthRating { get; set; }


    //
    public string PatientId { get; set; } = default!;
    public string PatientName { get; set; } = default!;
    public string PatientSurname { get; set; } = default!;
    public string PatientPesel { get; set; } = default!;
    public IEnumerable<string>? DoctorsId { get; set; } = new List<string>();
    public MedicalRecommandation? MedicalRecommandation { get; set; }

}
