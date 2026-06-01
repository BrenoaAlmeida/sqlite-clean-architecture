using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Contexto.Configuracoes;

internal sealed class CarroTypeConfiguration : IEntityTypeConfiguration<Carro>
{ 
    public void Configure(EntityTypeBuilder<Carro> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Nome)
            .IsRequired()
            .HasMaxLength(60);

        builder.Property(b => b.Preco)
            .IsRequired();

        builder.Property(b => b.Marca)
            .IsRequired()
            .HasMaxLength(60);        
    }
}
