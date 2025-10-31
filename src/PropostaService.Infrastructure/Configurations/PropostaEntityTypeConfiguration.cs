using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropostaService.Domain.Entities;

namespace PropostaService.Infrastructure.Configurations
{
    public class PropostaEntityTypeConfiguration : IEntityTypeConfiguration<Proposta>
    {
        public void Configure(EntityTypeBuilder<Proposta> builder)
        {
            builder.ToTable("Propostas");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedNever(); // Gerado no domínio (Guid.NewGuid)

            builder.Property(p => p.Numero)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.NomeCliente)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.ValorSeguro)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            // Enum armazenado como int
            builder.Property(p => p.Status)
                   .HasConversion<int>()
                   .IsRequired();

            builder.Property(p => p.DataCriacao)
                   .IsRequired();

            // Índices úteis
            builder.HasIndex(p => p.Numero).IsUnique();
            builder.HasIndex(p => p.Status);
        }
    }
}
