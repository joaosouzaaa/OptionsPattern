using OptionsPattern.API.Constants;
using OptionsPattern.API.Options;

namespace OptionsPattern.API.DependencyInjection;

internal static class OptionsDependencyInjection
{
    internal static void AddOptionsDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailCredentialsOptions>(configuration.GetSection(OptionsConstants.EmailCredentialsSection));
    }
}
