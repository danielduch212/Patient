using MediatR;
using Patient.Domain.Entities;
using Patient.Domain.Entities.DTOs.PrescriptionRequest;

namespace Patient.Application.PrescriptionRequests.Queries.Doctor.GetDoctorsPrescriptionRequests;

public class GetDoctorsPrescriptionRequestsQuery : IRequest<List<PrescriptionRequestToShowToDoctorDto>>
{

}
