using Microsoft.AspNetCore.Identity.UI.Services;
using Support.Microservice.Settings.EmailSettings;

namespace OptionsPattern.API.DependencyInjection;

internal static class SettingsDependencyInjection
{
    internal static void AddSettingsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IEmailSender, EmailSender>();
    }
}
