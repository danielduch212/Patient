using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Patient.Api.Client.Extensions;
using Patient.Api.Client.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<UserApiService>();




await builder.Build().RunAsync();


