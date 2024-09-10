﻿namespace Patient.Domain.Entities.Additional;

public class RegisterUserData
{
    public string Email { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string Pesel { get; set; } = default!;
    public string Password { get; set; } = default!;

}