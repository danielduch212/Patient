using MediatR;
using Shared.Dtos;

namespace Patient.Application.Diseases.Query.GetPatientsDiseases;

public class GetPatientsDiseasesQuery : IRequest<List<PatientsDiseaseDto>>
{

}
