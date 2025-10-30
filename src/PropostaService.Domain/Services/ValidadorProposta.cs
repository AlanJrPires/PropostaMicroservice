using PropostaService.Domain.Entities;
using PropostaService.Domain.Exceptions;

namespace PropostaService.Domain.Services
{
    /// <summary>
    /// Serviço de domínio responsável por validar regras específicas de proposta.
    /// Pode ser utilizado por casos de uso (na camada Application).
    /// </summary>
    public class ValidadorProposta
    {
        public void ValidarParaContratacao(Proposta proposta)
        {
            if (proposta == null)
                throw new PropostaInvalidaException("Proposta não encontrada.");

            if (proposta.Status != StatusProposta.Aprovada)
                throw new PropostaInvalidaException("Somente propostas aprovadas podem ser contratadas.");
        }

        public void ValidarParaAlterarStatus(Proposta proposta, StatusProposta novoStatus)
        {
            if (proposta == null)
                throw new PropostaInvalidaException("Proposta não encontrada.");

            if (proposta.Status == novoStatus)
                throw new PropostaInvalidaException($"A proposta já está com o status '{novoStatus}'.");
        }
    }
}
