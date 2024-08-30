
namespace Patient.Api.Client.AdditionalClasses;

public class ReportDtoFront
{
    public string Description { get; set; } = default!;
    public IEnumerable<Stream>? Files { get; set; } = new List<Stream>();
    public bool IsChecked { get; set; } = false;




    //

}
