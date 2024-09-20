using MediatR;
using Patient.Domain.Entities.DTOs;

namespace Patient.Application.MedicalData.Queries.Patient.GetMedicalFiles;

public class GetMedicalFilesQuery : IRequest<List<MedicalFileToShowDto>>
{

}
