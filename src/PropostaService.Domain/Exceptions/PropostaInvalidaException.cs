using System;

namespace PropostaService.Domain.Exceptions
{
    /// <summary>
    /// Exceção de domínio usada para sinalizar violações de regras de negócio.
    /// </summary>
    public class PropostaInvalidaException : Exception
    {
        public PropostaInvalidaException(string mensagem)
            : base(mensagem)
        {
        }
    }
}
