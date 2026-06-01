using Microsoft.EntityFrameworkCore;

namespace Domain.Contexto;

public class SqliteContext : DbContext
{
    public SqliteContext(DbContextOptions<SqliteContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        //Obtém dinamicamente todos os arquivos de configuração de classes e os aplica nas tabelas do Context
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqliteContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public virtual DbSet<Carro> Carros { get; set; }
}
