using Microsoft.AspNetCore.Identity;
using Patient.Api.Client.Pages;
using Patient.Api.Client.Services;
using Patient.Api.Components;
using Patient.Application.Extensions;
using Patient.Infrastructure.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Patient.Api.Middlewares;
using Patient.Api.Extensions;
using Serilog;


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

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

   

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Patient.Api.Client._Imports).Assembly);



app.Run();
