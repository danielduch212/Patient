
using Microsoft.Extensions.Configuration;
using Patient.Domain.Interfaces;
using Patient.Domain.Entities.Actors;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Patient.Infrastructure.ValidationUser.Services;

internal class TokenGenerator(IConfiguration _configuration, UserManager<User> userManager
    ) : ITokenGenerator
{
    public async Task<string> GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var roles = await userManager.GetRolesAsync(user);
        foreach(var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
