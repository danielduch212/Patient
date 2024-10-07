using MediatR;
using Patient.Domain.Entities.DTOs.PrescriptionRequest;

namespace Patient.Application.PrescriptionRequests.Commands.Doctor.PrescribePrescriptionFromRequest;

public class PrescribePrescriptionFromRequestCommand : IRequest<bool>
{
    public PrescriptionRequestToShowToDoctorDto Dto { get; set; } = new();
}
