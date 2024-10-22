using MediatR;
using Patient.Domain.Entities.DTOs.MedicalFiles;

namespace Patient.Application.MedicalData.Queries.Doctor.GetPatientsMedicalFiles;

public class GetPatientsMedicalFilesQuery : IRequest<List<MedicalFileToShowDto>>
{
    public string PatientId { get; set; }
}
