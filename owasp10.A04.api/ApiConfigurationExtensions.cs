using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace owasp10.A04.api;

public static class ApiConfigurationExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
