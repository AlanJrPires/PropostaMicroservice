using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PropostaService.Application.Ports;
using PropostaService.Application.Services;
using PropostaService.Domain.Services;
using PropostaService.Domain.Interfaces;
using PropostaService.Infrastructure.Persistence;

namespace PropostaService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPropostaInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Usa indexador em vez de GetValue para evitar dependência extra
            var provider = configuration["Database:Provider"] ?? "SqlServer";
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada.");

            if (provider.Equals("Postgres", StringComparison.OrdinalIgnoreCase) ||
                provider.Equals("PostgreSQL", StringComparison.OrdinalIgnoreCase))
            {
                services.AddDbContext<PropostaDbContext>(options =>
                    options.UseNpgsql(connectionString));
            }
            else
            {
                services.AddDbContext<PropostaDbContext>(options =>
                    options.UseSqlServer(connectionString));
            }

            services.AddScoped<IPropostaRepository, PropostaRepository>();
            services.AddScoped<ValidadorProposta>();

            return services;
        }
    }
}
