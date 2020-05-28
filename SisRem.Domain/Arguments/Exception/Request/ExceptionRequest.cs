
using SisRem.Domain.Interfaces.Arguments;
using System.Web.Script.Serialization;

namespace SisRem.Domain.Arguments.Exception.Request
{
    public class ExceptionRequest : IRequest
    {
        public string UsuarioLogado { get; set; }
        public string ClasseErro { get; set; }
        public string MetodoErro { get; set; }
        public string DescricaoErro { get; set; }
        public string StackTrace { get; set; }
        public string JsonRequest { get; set; }


        public static explicit operator ExceptionRequest(SisRem.Domain.Arguments.Usuario.Request.AdicionarRequest entidade)
        {
            return new ExceptionRequest()
            {
                ClasseErro = "UsuarioController",
                MetodoErro = "Adicionar",
                UsuarioLogado = entidade.UsuarioLogado,
                JsonRequest = new JavaScriptSerializer().Serialize(entidade)
            };
        }

    }
}
