using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Patient.Application.Users.Commands.Patients.Register;
using Patient.Domain.Entities.Actors;
using Patient.Domain.Interfaces;


namespace Patient.Application.Users.Commands.Patients.LogIn;

internal class LoginPatientCommandHandler(UserManager<User> userManager, ILogger<LoginPatientCommandHandler> logger,
IMapper mapper,  SignInManager<Patient.Domain.Entities.Actors.Patient> signInManager, 
ITokenGenerator tokenGenerator
) : IRequestHandler<LoginPatientCommand, string>
{
    public async Task<string> Handle(LoginPatientCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Trying login user by given email: {Email}",request.Email);

        var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
        
        string token = "";
        if (result.Succeeded)
        {
            User user = await userManager.FindByEmailAsync(request.Email);
            token = await tokenGenerator.GenerateToken(user);
        }
        return token;
        
    }
}
