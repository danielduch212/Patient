using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Patient.Infrastructure.Persistence;

namespace Patient.Infrastructure.Extensions;

public static class ServiceCollectionExtensions 
{

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PatientDb");
        services.AddDbContext<PatientDbContext>(options =>
            options.UseSqlServer(connectionString));


    }
}
