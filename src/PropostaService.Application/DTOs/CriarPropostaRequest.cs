namespace PropostaService.Application.DTOs
{
    /// <summary>
    /// Representa os dados necessários para criar uma nova proposta.
    /// </summary>
    public class CriarPropostaRequest
    {
        public string NomeCliente { get; set; } = string.Empty;
        public decimal ValorSeguro { get; set; }
    }
}
