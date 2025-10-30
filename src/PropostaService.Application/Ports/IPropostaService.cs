using PropostaService.Application.DTOs;

namespace PropostaService.Application.Ports
{
    /// <summary>
    /// Porta de entrada da aplicação (Application Service Port).
    /// Define os casos de uso que a camada de API pode chamar.
    /// </summary>
    public interface IPropostaService
    {
        Task<PropostaResponse> CriarPropostaAsync(CriarPropostaRequest request);
        Task<IEnumerable<PropostaResponse>> ListarPropostasAsync();
        Task<PropostaResponse> AlterarStatusAsync(AlterarStatusRequest request);
        Task<PropostaResponse?> ObterPorIdAsync(Guid id);
    }
}
