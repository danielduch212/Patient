using Patient.Api.Middlewares;

namespace Patient.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddServerApi(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ErrorHandlingMiddleware>();
    }
}
