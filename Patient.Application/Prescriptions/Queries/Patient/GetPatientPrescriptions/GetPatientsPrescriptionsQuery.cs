using MediatR;
using Patient.Domain.Entities.DTOs.Prescription;

namespace Patient.Application.Prescriptions.Queries.Patient.GetPatientPrescriptions;

public class GetPatientsPrescriptionsQuery : IRequest<List<PrescriptionToShowPatientDto>>
{

}
