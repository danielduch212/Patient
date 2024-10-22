using MediatR;
using Shared.Dtos;

namespace Patient.Application.Diseases.Query.Patient.GetPatientsDiseases;

public class GetPatientsDiseasesQuery : IRequest<List<PatientsDiseaseDto>>
{

}
