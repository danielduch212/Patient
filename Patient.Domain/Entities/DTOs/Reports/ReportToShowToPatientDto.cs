using Patient.Domain.Constants;
using Patient.Domain.Entities.Actors;
using Patient.Domain.Entities.Additional;

namespace Patient.Domain.Entities.DTOs.Reports;

public class ReportToShowToPatientDto
{
    public int Id { get; set; }
    public string Description { get; set; } = default!;
    public bool IsChecked { get; set; } = false;
    public string DateOfCreating { get; set; } = default!;
    public UrgencyType? Urgency { get; set; }
    public List<FilePreviewData> FilesPreviewData { get; set; } = new();
    public int PatientsHealthRating { get; set; }
    public List<string> PatientsAnswersForQuestions { get; set; } = new();
    public List<string> PatientsSymptoms { get; set; } = new();

    public IEnumerable<Doctor>? DoctorsWhoChecked { get; set; } = new List<Doctor>();
    public MedicalRecommandation? MedicalRecommandation { get; set; }


}