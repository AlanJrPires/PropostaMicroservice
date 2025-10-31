using Microsoft.EntityFrameworkCore;
using PropostaService.Domain.Entities;
using PropostaService.Infrastructure.Configurations;

namespace PropostaService.Infrastructure.Persistence
{
    public class PropostaDbContext : DbContext
    {
        public PropostaDbContext(DbContextOptions<PropostaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Proposta> Propostas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica configurações usando classes de configuração separadas
            modelBuilder.ApplyConfiguration(new PropostaEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
