using MediatR;
using Shared.Dtos;

namespace Patient.Application.Diseases.Query.Doctor.GetPatientsDiseases;

public class GetPatientsDiseasesQuery : IRequest<List<PatientsDiseaseDto>>
{
    public string PatientId { get; set; }
}
