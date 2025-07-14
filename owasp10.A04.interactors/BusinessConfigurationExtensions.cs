using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace owasp10.A04.interactors;

public static class BusinessConfigurationExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblies(Assembly.GetExecutingAssembly())
                                  .AddClasses()
                                  .AsImplementedInterfaces()
                                  .WithScopedLifetime());

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
