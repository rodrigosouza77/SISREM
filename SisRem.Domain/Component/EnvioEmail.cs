
using SisRem.Domain.Arguments.Email.Request;
using System;
using System.Configuration;
using System.Net.Mail;

namespace SisRem.Domain.Component
{
    public class EnvioEmail
    {
        public static bool EnviarEmail(EmailRequest request)
        {

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["EmailUserName"], ConfigurationManager.AppSettings["NomeCriptografado"]);

            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["EmailUserName"], ConfigurationManager.AppSettings["NameSystem"]);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailUserName"], ConfigurationManager.AppSettings["NameSystem"]);
            mail.To.Add(new MailAddress(request.Destinatario, ""));
            mail.Subject = request.Assunto;
            mail.Body = request.CorpoEmail;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                mail = null;
            }

            return true;

        }

    }
}
