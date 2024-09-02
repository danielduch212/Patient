using MediatR;
using Microsoft.AspNetCore.Identity;
namespace Patient.Application.Users.Commands.Patients.LogIn;

public class LoginPatientCommand : IRequest<SignInResult>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
