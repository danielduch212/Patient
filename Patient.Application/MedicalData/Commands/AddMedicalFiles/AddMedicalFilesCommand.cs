using MediatR;
using Patient.Domain.Entities.DTOs;

namespace Patient.Application.MedicalData.Commands.AddMedicalFiles;

public class AddMedicalFilesCommand : IRequest<bool>
{
    public IEnumerable<MedicalFileDto> medicalFileDtos = new List<MedicalFileDto>();
}
