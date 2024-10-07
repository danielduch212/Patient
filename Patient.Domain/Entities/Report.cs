using Patient.Domain.Constants;
using Patient.Domain.Entities.Actors;

namespace Patient.Domain.Entities;

public class Report
{
    public int Id { get; set; }
    public string? AdditionalDescription { get; set; } = default!;
    public List<string>? FileNames { get; set; } = new List<string>();
    public bool IsChecked { get; set; } = false;
    public string DateOfCreating { get; set; } = default!;
    public UrgencyType? Urgency { get; set; }
    public int PatientsHealthRating { get; set; } = default!;
    public List<string> PatientsAnswersForQuestions { get; set; } = new();
    public List<string> PatientsSymptoms { get; set; } = new();


    //
    public string PatientId { get; set; } = default!;
    public Patient.Domain.Entities.Actors.Patient Patient { get; set; } = default!;
    public int? MedicalRecommandationId { get; set; } = default!;
    public MedicalRecommandation? MedicalRecommandation { get; set; }
    public IEnumerable<Doctor>? DoctorsWhoChecked { get; set; } = new List<Doctor>();
    public IEnumerable<Doctor>? DoctorsToCheck { get; set; } = new List<Doctor>();
    

}
