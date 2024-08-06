using Microsoft.AspNetCore.Identity;

namespace Patient.Domain.Entities;

public class Doctor : IdentityUser
{
    public string DoctorNumber { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; } = default!;
    public Address Address { get; set; } = default!;


    //specjalizacje obsluze przez userroles z identity user]

    //
    public IEnumerable<Patient> Patients { get; set; } = new List<Patient>();
    public IEnumerable<Prescription> PrescriptionsIssued { get; set; } = new List<Prescription>();
    public IEnumerable<MedicalRecommandation> MedicalRecommandations { get; set; } = new List<MedicalRecommandation>();



}
