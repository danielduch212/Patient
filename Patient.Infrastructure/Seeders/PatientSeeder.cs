using Microsoft.AspNetCore.Identity;
using Patient.Infrastructure.Persistence;
using Patient.Domain.Entities;
using Patient.Domain.Constants;

namespace Patient.Infrastructure.Seeders;

internal class PatientSeeder(PatientDbContext dbContext) : IPatientSeeder
{
    public async Task SeedData()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if(!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                await dbContext.Roles.AddRangeAsync(roles);
                await dbContext.SaveChangesAsync();
            }
        }
    }


    private IEnumerable<IdentityRole> GetRoles()
    {

        List<IdentityRole> roles = [
            new (UserRoles.Patient){
                NormalizedName = UserRoles.Patient.ToUpper()
            },
            new (UserRoles.Doctor){
                NormalizedName = UserRoles.Doctor.ToUpper()
            },
            new (UserRoles.Admin){
                NormalizedName = UserRoles.Admin.ToUpper()
            },
            ];
        return roles;

    }


}
