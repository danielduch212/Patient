using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Persistence;
using Patient.Infrastructure.Repositories;
using Patient.Domain;
using Patient.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Patient.Domain.Entities.Actors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace Patient.Infrastructure.Extensions;

public static class ServiceCollectionExtensions 
{

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PatientDb");
        services.AddDbContext<PatientDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddIdentity<User, IdentityRole>(options =>
         {
             options.User.RequireUniqueEmail = true;
         })
         .AddEntityFrameworkStores<PatientDbContext>()
         .AddDefaultTokenProviders();

        services.AddScoped<UserManager<Patient.Domain.Entities.Actors.Patient>>();
        services.AddScoped<IUserStore<Patient.Domain.Entities.Actors.Patient>, UserStore<Patient.Domain.Entities.Actors.Patient, IdentityRole, PatientDbContext, string>>();
        services.AddScoped<SignInManager<Patient.Domain.Entities.Actors.Patient>>();

        services.AddScoped<IPasswordHasher<Patient.Domain.Entities.Actors.Patient>, PasswordHasher<Patient.Domain.Entities.Actors.Patient>>();


        services.AddScoped<IReportRepository, ReportRepository>();
        


    }
}
