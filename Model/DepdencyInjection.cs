using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Model;

public static class DepdencyInjection
{
    public static IServiceCollection AddModelConfiguration(this IServiceCollection services, string connectionString)
    {
        // O projeto Model tem acesso nativo ao AddDbContext porque ele já tem o EF Core
        services.AddDbContext<Context>(options => options.UseSqlite(connectionString));
        return services;
    }

}
