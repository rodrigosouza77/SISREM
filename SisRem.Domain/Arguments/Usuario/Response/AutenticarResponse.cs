using System;

namespace SisRem.Domain.Arguments.Usuario
{
    public class AutenticarResponse
    {
        public int Id { get; set; }

        public string PrimeiroNome { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }

        public static explicit operator AutenticarResponse(Entities.Usuario entidade)
        {
            return new AutenticarResponse() {
                Id = entidade.Id,
                Email = entidade.Email.Endereco,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                Status = (int)entidade.Status
            };
        }
    }
}
