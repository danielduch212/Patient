using Microsoft.AspNetCore.Identity;
using Patient.Domain.Entities.Additional;

namespace Patient.Domain.Entities.Actors;

public class Doctor : User
{
    public string DoctorNumber { get; set; } = default!;
    public string? DoctorSpecialization { get; set; } = default!;


    //specjalizacje obsluze przez userroles z identity user

    //
    public IEnumerable<Patient> Patients { get; set; } = new List<Patient>();
    public IEnumerable<Prescription> PrescriptionsIssued { get; set; } = new List<Prescription>();
    public IEnumerable<MedicalRecommandation> MedicalRecommandations { get; set; } = new List<MedicalRecommandation>();
    public IEnumerable<Report>? ReportsToCheck { get; set; } = new List<Report>();
    public IEnumerable<Report>? ReportsChecked { get; set; } = new List<Report>();


}
