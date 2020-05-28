using System;

namespace SisRem.Domain.Arguments.Usuario.Response
{
    public class AlterarResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Message { get; set; }

        public static explicit operator AlterarResponse(Entities.Usuario entidade)
        {
            return new AlterarResponse() {
                Email = entidade.Email.Endereco,
                Id = entidade.Id,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                UltimoNome = entidade.Nome.UltimoNome,
                Message = Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO

            };
        }
    }
}
