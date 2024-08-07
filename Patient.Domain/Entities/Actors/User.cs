using Microsoft.AspNetCore.Identity;
using Patient.Domain.Entities.Additional;

namespace Patient.Domain.Entities.Actors;

public class User : IdentityUser
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; } = default!;
    public Address Address { get; set; } = default!;

}
