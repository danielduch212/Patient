using MediatR;
using Patient.Domain.Entities.DTOs.MedicalFiles;

namespace Patient.Application.MedicalData.Commands.Patient.AddMedicalFiles;

public class AddMedicalFilesCommand : IRequest<bool>
{
    public IEnumerable<MedicalFileDto> medicalFileDtos = new List<MedicalFileDto>();
}
