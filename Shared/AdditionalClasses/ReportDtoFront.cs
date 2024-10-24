
namespace Shared.AdditionalClasses;

public class ReportDtoFront
{
    public List<string> PatientsAnswers = new();
    public string Description { get; set; } = "";
    public int PatientsHealthRating { get; set; }
    public List<string> PatientsSymptoms { get; set; } = new();
    public IEnumerable<Stream>? Files { get; set; } = new List<Stream>();
    public IEnumerable<string>? FileNames { get; set; } = new List<string>();


    //

}
