using System;

namespace SisRem.Domain.Arguments.Usuario.Request
{
    public class AlterarRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string UsuarioLogado { get; set; }

    }
}
