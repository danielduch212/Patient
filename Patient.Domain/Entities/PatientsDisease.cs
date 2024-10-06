using Shared.Main;

namespace Patient.Domain.Entities;

public class PatientsDisease
{
    public int Id { get; set; }
    public int DiseaseId { get; set; } = default!;
    public string? UserExperienceWithDisease { get; set; }=default!;
    public bool IsCurrentlyTreated { get; set; }



    //
    public string PatientId { get; set; } = default!;
    public Patient.Domain.Entities.Actors.Patient Patient { get; set; } = default!;
}
