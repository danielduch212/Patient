using Shared.Main;

namespace Shared.Dtos;

public class PatientsDiseaseDto
{
    public int IdToDistinction { get; set; }
    public Disease Disease { get; set; } = default!;
    public string? UserExperienceWithDisease { get; set; } = "";
    public bool IsCurrentlyTreated { get; set; }
}
