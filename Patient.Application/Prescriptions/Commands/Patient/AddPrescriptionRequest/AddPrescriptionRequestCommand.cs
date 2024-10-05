using MediatR;
using Patient.Domain.Entities.DTOs.PrescriptionRequest;

namespace Patient.Application.Prescriptions.Commands.Patient.AskForPrescription;

public class AddPrescriptionRequestCommand : IRequest<bool>
{
    public PrescriptionRequestDto Dto { get; set; } = default!;
}
