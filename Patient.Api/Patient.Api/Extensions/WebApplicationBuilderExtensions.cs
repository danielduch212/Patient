using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Patient.Api.Middlewares;
using System.Text;
using Serilog;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Patient.Application.Account;
using Patient.Domain.Interfaces;

using MudBlazor.Services;

namespace Patient.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddServerApi(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ErrorHandlingMiddleware>();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            
        })
            .AddIdentityCookies();

        builder.Services.AddAuthorization();
        builder.Services.AddCascadingAuthenticationState();       

        builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration)

        );

        builder.Services.AddMudServices();

    }

}
