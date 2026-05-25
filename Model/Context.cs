using Microsoft.EntityFrameworkCore;

namespace Model;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }    

    public virtual DbSet<Carro> Carros { get; set; }
}
