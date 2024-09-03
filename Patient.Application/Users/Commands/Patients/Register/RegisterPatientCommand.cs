using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Identity;

namespace Patient.Application.Users.Commands.Patients.Register;

public class RegisterPatientCommand() : IRequest<IdentityOperationResult>
{
    public string Email { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string Pesel { get; set; } = default!;
    public string Password { get; set; } = default!;
}
