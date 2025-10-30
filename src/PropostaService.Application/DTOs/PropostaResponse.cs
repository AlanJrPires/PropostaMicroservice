using PropostaService.Domain.Entities;

namespace PropostaService.Application.DTOs
{
    /// <summary>
    /// Representa a resposta padrão de uma proposta retornada pela API.
    /// </summary>
    public class PropostaResponse
    {
        public Guid Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string NomeCliente { get; set; } = string.Empty;
        public decimal ValorSeguro { get; set; }
        public StatusProposta Status { get; set; }
        public DateTime DataCriacao { get; set; }

        public static PropostaResponse FromEntity(Proposta proposta)
        {
            return new PropostaResponse
            {
                Id = proposta.Id,
                Numero = proposta.Numero,
                NomeCliente = proposta.NomeCliente,
                ValorSeguro = proposta.ValorSeguro,
                Status = proposta.Status,
                DataCriacao = proposta.DataCriacao
            };
        }
    }
}
