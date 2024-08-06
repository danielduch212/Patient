using Microsoft.AspNetCore.Identity;
using Patient.Domain.Constants;

namespace Patient.Domain.Entities;

public class Patient : IdentityUser
{
    public string Pesel { get; set; } = default!;
    public string Name { get; set; } = default!; 
    public string Surname { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; } = default!;
    public Address Address { get; set; } = default!;
    public PatientType PatientType { get; set; }


    //
    public IEnumerable<Report>? Reports { get; set; } = new List<Report>();
    public IEnumerable<Doctor>? Doctors { get; set; } = new List<Doctor>();
    public IEnumerable<MedicalFile>? MedicalFiles { get; set; } = new List<MedicalFile>();
    public IEnumerable<Prescription>? Prescriptions { get; set; } = new List<Prescription>();




}
