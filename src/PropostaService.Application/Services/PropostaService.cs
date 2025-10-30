using PropostaService.Application.DTOs;
using PropostaService.Application.Ports;
using PropostaService.Domain.Entities;
using PropostaService.Domain.Interfaces;
using PropostaService.Domain.Services;
using PropostaService.Domain.Exceptions;

namespace PropostaService.Application.Services
{
    /// <summary>
    /// Implementação dos casos de uso relacionados a Proposta.
    /// Aplica as regras de negócio do domínio e orquestra as portas de saída.
    /// </summary>
    public class PropostaService : IPropostaService
    {
        private readonly IPropostaRepository _propostaRepository;
        private readonly ValidadorProposta _validador;

        public PropostaService(IPropostaRepository propostaRepository, ValidadorProposta validador)
        {
            _propostaRepository = propostaRepository;
            _validador = validador;
        }

        /// <summary>
        /// Cria uma nova proposta.
        /// </summary>
        public async Task<PropostaResponse> CriarPropostaAsync(CriarPropostaRequest request)
        {
            var proposta = new Proposta(request.NomeCliente, request.ValorSeguro);
            await _propostaRepository.AdicionarAsync(proposta);
            await _propostaRepository.SalvarAlteracoesAsync();

            return PropostaResponse.FromEntity(proposta);
        }

        /// <summary>
        /// Lista todas as propostas existentes.
        /// </summary>
        public async Task<IEnumerable<PropostaResponse>> ListarPropostasAsync()
        {
            var propostas = await _propostaRepository.ListarTodasAsync();
            return propostas.Select(PropostaResponse.FromEntity);
        }

        /// <summary>
        /// Altera o status de uma proposta conforme regras de negócio.
        /// </summary>
        public async Task<PropostaResponse> AlterarStatusAsync(AlterarStatusRequest request)
        {
            var proposta = await _propostaRepository.ObterPorIdAsync(request.PropostaId);
            if (proposta == null)
                throw new PropostaInvalidaException("Proposta não encontrada.");

            _validador.ValidarParaAlterarStatus(proposta, request.NovoStatus);
            proposta.AlterarStatus(request.NovoStatus);

            await _propostaRepository.AtualizarAsync(proposta);
            await _propostaRepository.SalvarAlteracoesAsync();

            return PropostaResponse.FromEntity(proposta);
        }

        /// <summary>
        /// Busca uma proposta específica por ID.
        /// </summary>
        public async Task<PropostaResponse?> ObterPorIdAsync(Guid id)
        {
            var proposta = await _propostaRepository.ObterPorIdAsync(id);
            return proposta is null ? null : PropostaResponse.FromEntity(proposta);
        }
    }
}
