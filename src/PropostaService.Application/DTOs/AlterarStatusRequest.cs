using PropostaService.Domain.Entities;

namespace PropostaService.Application.DTOs
{
    /// <summary>
    /// Representa os dados necessários para alterar o status de uma proposta.
    /// </summary>
    public class AlterarStatusRequest
    {
        public Guid PropostaId { get; set; }
        public StatusProposta NovoStatus { get; set; }
    }
}
