using OptionsPattern.API.Interfaces.Services;
using OptionsPattern.API.Services;

namespace OptionsPattern.API.DependencyInjection;

internal static class ServicesDependencyInjection
{
    internal static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
    }
}
