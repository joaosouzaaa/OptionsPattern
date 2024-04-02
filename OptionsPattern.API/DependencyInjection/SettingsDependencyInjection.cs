using OptionsPattern.API.Interfaces.Settings;
using OptionsPattern.API.Settings.EmailSettings;

namespace OptionsPattern.API.DependencyInjection;

internal static class SettingsDependencyInjection
{
    internal static void AddSettingsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IEmailSender, EmailSender>();
    }
}
