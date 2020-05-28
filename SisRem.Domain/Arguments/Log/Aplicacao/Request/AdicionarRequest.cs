using SisRem.Domain.Enum;
using SisRem.Domain.Resources;
using SisRem.Domain.Interfaces.Arguments;

namespace SisRem.Domain.Arguments.Log.Aplicacao.Request
{
    public class AdicionarRequest : IRequest
    {

        public string UsuarioLogado { get; set; }
        public EnumTipoLogAplicacao TipoLogAplicacao { get; set; }
        public string Valor { get; set; }
        public EnumIdTabela IdTabela { get; set; }
        public string Messagem { get; set; }


        public static explicit operator AdicionarRequest(SisRem.Domain.Arguments.Usuario.Request.AdicionarRequest entidade)
        {
            return new AdicionarRequest()
            {
                UsuarioLogado = entidade.UsuarioLogado,
                TipoLogAplicacao = EnumTipoLogAplicacao.Inclusao,
                Valor = entidade.PrimeiroNome + " " + entidade.UltimoNome,
                IdTabela = EnumIdTabela.Usuario,
                Messagem = Message.INCLUSAO_USUARIO
            };
        }

        public static explicit operator AdicionarRequest(SisRem.Domain.Arguments.Usuario.Request.AlterarRequest entidade)
        {
            return new AdicionarRequest()
            {
                UsuarioLogado = entidade.UsuarioLogado,
                TipoLogAplicacao = EnumTipoLogAplicacao.Alteracao,
                Valor = entidade.PrimeiroNome + " " + entidade.UltimoNome,
                IdTabela = EnumIdTabela.Usuario,
                Messagem = Message.INCLUSAO_USUARIO
            };
        }



    }
}
