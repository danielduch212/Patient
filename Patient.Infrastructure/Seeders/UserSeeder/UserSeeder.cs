using HtmlAgilityPack;
using System.Net.Http;
using System.Security.Policy;
using Patient.Infrastructure.Persistence;
using Patient.Domain.Entities;
using Patient.Domain.Entities.Actors;
using Patient.Domain.Entities.Additional;
using Patient.Domain.Constants;
using Microsoft.EntityFrameworkCore;

namespace Patient.Infrastructure.Seeders.UserSeeder;

internal class UserSeeder(HttpClient _httpClient, PatientDbContext dbContext) : IUserSeeder
{

    public async Task SeedUsers()
    {

        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Medicines.Any())
            {
                await dbContext.SaveChangesAsync();
            }
        }
    }

    
    

    //
    
}
