
using SisRem.Domain.Interfaces.Arguments;
using System;
using System.Configuration;

namespace SisRem.Domain.Arguments.Email.Request
{
    public class EmailRequest : IRequest
    {
        public string Assunto { get; set; }
        public string CorpoEmail { get; set; }
        public string Destinatario { get; set; }

        public static explicit operator EmailRequest(SisRem.Domain.Arguments.Usuario.Request.AdicionarRequest entidade)
        {
            return new EmailRequest()
            {
                Assunto = ConfigurationManager.AppSettings["NameSystem"] + " - Cadastro de Usuário",
                CorpoEmail = "Usuário(a) " + entidade.PrimeiroNome + " " + entidade.UltimoNome + " cadastrado(a) com sucesso!",
                Destinatario = entidade.UsuarioLogado,
            };
        }

        public static explicit operator EmailRequest(SisRem.Domain.Arguments.Exception.Request.ExceptionRequest entidade)
        {
            return new EmailRequest()
            {
                Assunto = "Exception/Erro - " + DateTime.Now.ToString() + " - " + entidade.ClasseErro + " - " + entidade.DescricaoErro ,
                CorpoEmail = "Usuário(a): " + entidade.UsuarioLogado + "<br>" + "<br>" +
                             "-- Dados do Erro -- " + "<br>" +
                             "Classe: " + entidade.ClasseErro + "<br>" +
                             "Método: " + entidade.MetodoErro + "<br>" +
                             "Descrição: " + entidade.DescricaoErro + "<br>" +
                             "Data: " + DateTime.Now.ToString() + "<br>" + "<br>" +
                             "Request/Json: " + "<br>" +
                             entidade.JsonRequest
                             + "<br>" + "<br>" + 
                             "Detalhamento: " + "<br>" +
                             entidade.StackTrace.ToString(),
                Destinatario = ConfigurationManager.AppSettings["EmailExceptions"]
            };
        }

    }
}
