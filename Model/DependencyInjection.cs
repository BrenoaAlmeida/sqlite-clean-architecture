using Domain.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddModelConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        // O projeto Model tem acesso nativo ao AddDbContext porque ele já tem o EF Core
        services.AddDbContext<SqliteContext>(options => options.UseSqlite(configuration.GetConnectionString("MinhaConexaoSqlite")));

        //Injetando o context necessario para o repositorio generico funcionar
        services.AddScoped<DbContext>(provider => provider.GetRequiredService<SqliteContext>());
        return services;
    }
}
