using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Application.Users.Commands.Patients.Register;


namespace Patient.Application.Users.Commands.Patients.LogIn;

internal class LoginPatientCommandHandler(UserManager<Patient.Domain.Entities.Actors.Patient> userManager, ILogger<RegisterPatientCommandHandler> logger,
IMapper mapper, SignInManager<Patient.Domain.Entities.Actors.Patient> signInManager) : IRequestHandler<LoginPatientCommand, SignInResult>
{
    public Task<SignInResult> Handle(LoginPatientCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Trying login user by given email: {Email}",request.Email);

        var result = signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
        return result;
    }
}
