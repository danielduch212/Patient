using Patient.Domain.Constants;

namespace Patient.Domain.Entities.Actors;

public class Patient : User
{
    public string Pesel { get; set; } = default!;
    public PatientType PatientType { get; set; }
    public bool PreventionPatient { get; set; }
    //public string Sex = //mezczyzna/kobieta
    public string? ImageAvatarFileName { get; set; } = default!;

    //
    public IEnumerable<PatientsDisease> TreatedDiseases { get; set; } = new List<PatientsDisease>();


    public IEnumerable<Report>? Reports { get; set; } = new List<Report>();
    public IEnumerable<Doctor>? Doctors { get; set; } = new List<Doctor>();
    public IEnumerable<MedicalFile>? MedicalFiles { get; set; } = new List<MedicalFile>();
    public IEnumerable<Prescription>? Prescriptions { get; set; } = new List<Prescription>();




}
