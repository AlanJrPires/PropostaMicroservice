using PropostaService.Domain.Exceptions;

namespace PropostaService.Domain.Entities
{
    /// <summary>
    /// Entidade de domínio que representa uma proposta de seguro.
    /// É o agregado raiz (Aggregate Root) do contexto de Propostas.
    /// </summary>
    public class Proposta
    {
        public Guid Id { get; private set; }
        public string Numero { get; private set; }
        public string NomeCliente { get; private set; }
        public decimal ValorSeguro { get; private set; }
        public StatusProposta Status { get; private set; }
        public DateTime DataCriacao { get; private set; }

        /// <summary>
        /// Construtor protegido para uso do ORM (EF Core) e reidratação.
        /// </summary>
        protected Proposta() { }

        /// <summary>
        /// Construtor principal de domínio.
        /// </summary>
        public Proposta(string nomeCliente, decimal valorSeguro)
        {
            if (string.IsNullOrWhiteSpace(nomeCliente))
                throw new PropostaInvalidaException("O nome do cliente é obrigatório.");

            if (valorSeguro <= 0)
                throw new PropostaInvalidaException("O valor do seguro deve ser maior que zero.");

            Id = Guid.NewGuid();
            Numero = GerarNumeroProposta();
            NomeCliente = nomeCliente;
            ValorSeguro = valorSeguro;
            Status = StatusProposta.EmAnalise;
            DataCriacao = DateTime.UtcNow;
        }

        /// <summary>
        /// Altera o status da proposta, respeitando as regras de negócio.
        /// </summary>
        public void AlterarStatus(StatusProposta novoStatus)
        {
            // Regras de negócio
            if (Status == StatusProposta.Aprovada && novoStatus == StatusProposta.EmAnalise)
                throw new PropostaInvalidaException("Não é permitido retornar uma proposta aprovada para 'Em Análise'.");

            if (Status == StatusProposta.Rejeitada && novoStatus == StatusProposta.EmAnalise)
                throw new PropostaInvalidaException("Não é permitido reabrir uma proposta rejeitada.");

            Status = novoStatus;
        }

        /// <summary>
        /// Gera um número de proposta no formato "PRP-2025XXXX".
        /// </summary>
        private static string GerarNumeroProposta()
        {
            var sequencia = new Random().Next(1000, 9999);
            return $"PRP-{DateTime.UtcNow.Year}{sequencia}";
        }
    }
}
