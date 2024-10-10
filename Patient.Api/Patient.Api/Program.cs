using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Patient.Api.Client.Services;
using Patient.Api.Components;
using Patient.Api.Extensions;
using Patient.Api.Middlewares;
using Patient.Application.Extensions;
using Patient.Domain.Repositories;
using Patient.Infrastructure.Extensions;
using Patient.Infrastructure.Seeders;
using Patient.Infrastructure.Seeders.DiseaseSeeder;
using Patient.Infrastructure.Seeders.MedicineSeeder;
using Serilog;


try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents()
        .AddInteractiveWebAssemblyComponents();

    builder.Services.AddInfrastructure(builder.Configuration);
    builder.AddServerApi();
    builder.Services.AddApplication();



    builder.Services.AddScoped(sp => new HttpClient
    {
        BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value)
    });



    builder.Services.AddScoped<UserApiService>();


    builder.Services.AddControllers();




    var app = builder.Build();

    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<IPatientSeeder>();
    var medicineSeeder = scope.ServiceProvider.GetRequiredService<IUserSeeder>();
    var diseaseSeeder = scope.ServiceProvider.GetRequiredService<IDiseaseSeeder>();


    await seeder.SeedData();
    await medicineSeeder.SeedMedicines();
    await diseaseSeeder.SeedData();



    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseSerilogRequestLogging();

    
    
    app.UseWebAssemblyDebugging();
    
    //else
    //{
    //    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    //    app.UseHsts();
    //}

    app.UseHttpsRedirection();


    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.UseStaticFiles();
    app.UseAntiforgery();



    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode()
        .AddInteractiveWebAssemblyRenderMode()
        .AddAdditionalAssemblies(typeof(Patient.Api.Client._Imports).Assembly);



    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Appliacation startup failed");
}
finally
{
    Log.CloseAndFlush();
}

