
using SisRem.Domain.Arguments.Email.Request;
using System;
using System.Configuration;

namespace SisRem.Domain.Component
{
    public static class HelperEnvioEmail
    {

        public static bool EnviarEmail(EmailRequest request)
        {
            bool status = false;
            try
            {
                var emailHabilitado = Convert.ToBoolean(ConfigurationManager.AppSettings["EmailEnvioHabilitado"]);

                if (!emailHabilitado)
                    return false;

                status = EnvioEmail.EnviarEmail(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }


    }
}
