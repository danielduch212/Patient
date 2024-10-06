using MediatR;
using Shared.Dtos;

namespace Patient.Application.Diseases.Command.Patient.AddPatientsDiseases;

public class AddPatientsDiseasesCommand : IRequest<bool>
{
    public List<PatientsDiseaseDto> Dtos { get; set; } = new();
}
