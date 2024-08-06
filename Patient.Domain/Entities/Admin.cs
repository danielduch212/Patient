using Microsoft.AspNetCore.Identity;


namespace Patient.Domain.Entities;


public class Admin : IdentityUser
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;

}
