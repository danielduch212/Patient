
namespace Shared.AdditionalClasses;

public class ReportDtoFront
{
    public string Description { get; set; } = default!;
    public IEnumerable<Stream>? Files { get; set; } = new List<Stream>();
    public IEnumerable<string>? FileNames { get; set; } = new List<string>();

    




    //

}
