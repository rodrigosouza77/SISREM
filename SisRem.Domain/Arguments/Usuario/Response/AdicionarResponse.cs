using System;
using SisRem.Domain.Interfaces.Arguments;

namespace SisRem.Domain.Arguments.Usuario.Response
{
    public class AdicionarResponse : IResponse
    {
        public int Id { get; set; }

        public string Message { get; set; }


        public static explicit operator AdicionarResponse(Entities.Usuario entidade)
        {
            return new AdicionarResponse() {
                Id = entidade.Id,
                Message = SisRem.Domain.Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
