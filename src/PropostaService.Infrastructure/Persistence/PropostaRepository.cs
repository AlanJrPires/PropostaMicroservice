using Microsoft.EntityFrameworkCore;
using PropostaService.Domain.Entities;
using PropostaService.Domain.Interfaces;

namespace PropostaService.Infrastructure.Persistence
{
    /// <summary>
    /// Implementação do repositório (porta de saída) usando EF Core.
    /// </summary>
    public class PropostaRepository : IPropostaRepository
    {
        private readonly PropostaDbContext _dbContext;

        public PropostaRepository(PropostaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AdicionarAsync(Proposta proposta)
        {
            if (proposta is null) throw new ArgumentNullException(nameof(proposta));
            await _dbContext.Propostas.AddAsync(proposta);
        }

        public async Task<Proposta?> ObterPorIdAsync(Guid id)
        {
            return await _dbContext.Propostas
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Proposta>> ListarTodasAsync()
        {
            return await _dbContext.Propostas
                .AsNoTracking()
                .OrderByDescending(p => p.DataCriacao)
                .ToListAsync();
        }

        public Task AtualizarAsync(Proposta proposta)
        {
            if (proposta is null) throw new ArgumentNullException(nameof(proposta));
            _dbContext.Propostas.Update(proposta);
            return Task.CompletedTask;
        }

        public async Task SalvarAlteracoesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
