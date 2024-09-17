using MediatR;
using Patient.Domain.Entities.DTOs;

namespace Patient.Application.MedicalData.Queries.GetMedicalFiles;

public class GetMedicalFilesQuery : IRequest<List<MedicalFileToShowDto>>
{

}
