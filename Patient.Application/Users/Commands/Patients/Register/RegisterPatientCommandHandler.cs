using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Domain.Entities.Actors;

namespace Patient.Application.Users.Commands.Patients.Register;

internal class RegisterPatientCommandHandler(UserManager<Patient.Domain.Entities.Actors.Patient> userManager, ILogger<RegisterPatientCommandHandler> logger,
    IMapper mapper) : IRequestHandler<RegisterPatientCommand, IdentityResult>
{
    public async Task<IdentityResult> Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Trying register user");
        var user = mapper.Map<Patient.Domain.Entities.Actors.Patient>(request);
        var result = await userManager.CreateAsync(user);
        return result;
    }
}
