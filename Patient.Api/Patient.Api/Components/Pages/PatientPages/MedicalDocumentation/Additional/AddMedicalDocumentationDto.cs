using Microsoft.AspNetCore.Components.Forms;

namespace Patient.Api.Components.Pages.PatientPages.MedicalDocumentation.Additional;

public class AddMedicalDocumentationDto
{
    public IBrowserFile FilePreview {  get; set; }
    public string? Description { get; set; }
    public string MedicalDocumentationType { get; set; } = default!;
    public bool AddDescription { get; set; }
}
