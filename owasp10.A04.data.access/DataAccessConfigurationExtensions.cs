using Microsoft.Extensions.DependencyInjection;
using owasp10.A04.business.Data;
using owasp10.A04.data.access.Repositories;
using System.Reflection;

namespace owasp10.A04.data.access;

public static class DataAccessConfigurationExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(ISqLiteRepository<>), typeof(SQLiteRepository<>));

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
