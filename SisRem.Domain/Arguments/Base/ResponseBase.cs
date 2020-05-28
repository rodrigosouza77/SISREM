using System;
using SisRem.Domain.Entities;

namespace SisRem.Domain.Arguments.Base
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Message = SisRem.Domain.Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO;
        }
        public int Id { get; set; }
        public string Message { get; set; }

        public static explicit operator ResponseBase(Entities.Usuario entidade)
        {
            return new ResponseBase() {
                Message = Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
