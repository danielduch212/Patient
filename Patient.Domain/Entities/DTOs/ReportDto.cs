using Patient.Domain.Constants;

namespace Patient.Domain.Entities.DTOs;

public class ReportDto
{
    public string Description { get; set; } = default!;
    public IEnumerable<Stream>? Files { get; set; } = new List<Stream>();
    public IEnumerable<string>? FileNames { get; set; } = new List<string>();
    public bool IsChecked { get; set; } = false;




    //
    public string PatientId { get; set; } = default!;
    public Patient.Domain.Entities.Actors.Patient Patient { get; set; } = default!;
}
