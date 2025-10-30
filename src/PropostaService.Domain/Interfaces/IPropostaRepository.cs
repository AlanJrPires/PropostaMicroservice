using PropostaService.Domain.Entities;

namespace PropostaService.Domain.Interfaces
{
    /// <summary>
    /// Porta de saída do domínio (Repository Port).
    /// Define o contrato que a camada de infraestrutura deve implementar.
    /// </summary>
    public interface IPropostaRepository
    {
        Task<Proposta?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Proposta>> ListarTodasAsync();
        Task AdicionarAsync(Proposta proposta);
        Task AtualizarAsync(Proposta proposta);
        Task SalvarAlteracoesAsync();
    }
}
