using MediatR;
using Patient.Domain.Entities.DTOs.Recommandation;

namespace Patient.Application.Recommandation.Commands.Doctor.CreateRecommandation;

public class CreateRecommandationCommand : IRequest<bool>
{
    public MedicalRecommandationDto MedicalRecommandationDto { get; set; } = default!;
}
