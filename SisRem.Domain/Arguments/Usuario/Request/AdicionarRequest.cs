using SisRem.Domain.Entities.Log;
using SisRem.Domain.Interfaces.Arguments;
using SisRem.Domain.ValueObjects;

namespace SisRem.Domain.Arguments.Usuario.Request
{
    public class AdicionarRequest : IRequest
    {
        public string UsuarioLogado { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }

    }
}
