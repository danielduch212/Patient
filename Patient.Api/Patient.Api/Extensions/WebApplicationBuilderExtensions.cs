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

        //.AddJwtBearer(options =>
        //{
        //        options.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,
        //            ValidIssuer = builder.Configuration["Jwt:Issuer"],
        //            ValidAudience = builder.Configuration["Jwt:Audience"],
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        //            RoleClaimType = ClaimTypes.Role,

        //        };
        //});
        //builder.Services.AddAuthentication(options =>
        //{
        //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //})

        builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration)

        );

        builder.Services.AddMudServices();

    }

}
