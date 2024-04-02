namespace OptionsPattern.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddCorsDependencyInjection();
    }
}
