using Shared.Main;

namespace Shared.Dtos;

public class PatientsDiseaseDto
{
    public int IdToDistinction { get; set; }
    public Disease Disease { get; set; } = default!;
    public string? UserExperienceWithDisease { get; set; } = default!;
    public bool IsCurrentlyTreated { get; set; }
}
