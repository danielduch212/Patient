using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Patient.Domain.Entities.Actors;
using Patient.Domain.Interfaces;
using Shared.Identity;

namespace Patient.Application.Users.Commands.Patients.Register;

internal class RegisterPatientCommandHandler(UserManager<Patient.Domain.Entities.Actors.Patient> userManager, ILogger<RegisterPatientCommandHandler> logger,
    IMapper mapper, IUserAdditionalValidator userAdditionalValidator, IPasswordHasher<Patient.Domain.Entities.Actors.Patient> passwordHasher) : IRequestHandler<RegisterPatientCommand, IdentityOperationResult>
{
    public async Task<IdentityOperationResult> Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Trying register user");
        IdentityOperationResult result = new();
        (var isDataValidate, var message) = await userAdditionalValidator.ValidatePatientData(request.Pesel, request.Email);
        if (isDataValidate)
        {
                        
            var user = mapper.Map<Patient.Domain.Entities.Actors.Patient>(request);
            var hashedPassword = passwordHasher.HashPassword(user,request.Password);
            user.PasswordHash = hashedPassword;
            var resultFromCreating = await userManager.CreateAsync(user);
            result.IsSuccess = resultFromCreating.Succeeded;
            result.Errors = resultFromCreating.Errors.Select(e => e.Description.ToString()).ToList();
            return result;

        }
        result.IsSuccess = isDataValidate;
        List<string> messageError = new List<string>();
        messageError.Add(message);
        result.Errors = messageError;
                
        return result;
    }
}
