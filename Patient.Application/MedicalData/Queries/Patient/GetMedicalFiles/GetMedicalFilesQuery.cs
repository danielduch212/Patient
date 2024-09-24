using MediatR;
using Patient.Domain.Entities.DTOs.MedicalFiles;

namespace Patient.Application.MedicalData.Queries.Patient.GetMedicalFiles;

public class GetMedicalFilesQuery : IRequest<List<MedicalFileToShowDto>>
{

}
