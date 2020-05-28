using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using SisRem.Domain.Entities.Base;
using SisRem.Domain.Enum;
using SisRem.Domain.Extensions;
using SisRem.Domain.Resources;
using SisRem.Domain.ValueObjects;
using System.Collections.Generic;
using SisRem.Domain.Entities.Log;

namespace SisRem.Domain.Entities
{
    public class Usuario : EntityBase
    {
        protected Usuario()
        {

        }
        public Usuario(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Usuario>(this).IfNullOrInvalidLength(x => x.Senha, 1, 6, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "1", "6"));

            if (IsValid())
            {
                Senha = Senha.ConvertToMD5();
            }
        }

        public Usuario(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Status = EnumSituacaoUsuario.Ativo;

            new AddNotifications<Usuario>(this)
                .IfNullOrInvalidLength(x => x.Senha, 1, 6, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "1", "6"))
                .IfNullOrInvalidLength(x => x.Email.Endereco, 1, 60, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("E-mail", "1", "60"));           

            if (IsValid())
            {
                Senha = Senha.ConvertToMD5();
            }

            AddNotifications(nome, email);
        }

        //public void AlterarUsuario(Nome nome, Email email, EnumSituacaoUsuario status)
        public void AlterarUsuario(Nome nome, EnumSituacaoUsuario status)
        {
            Nome = nome;
            //Email = email;

            new AddNotifications<Usuario>(this).IfFalse(Status == EnumSituacaoUsuario.Ativo, "Só é possível alterar Usuario se ele estiver ativo.");

            AddNotifications(nome);
        }

        public Nome Nome { get; private set; }

        public Email Email { get; private set; }

        public string Senha { get; private set; }

        public EnumSituacaoUsuario Status { get; private set; }

        public virtual IList<LogAplicacao> LogsAplicacao { get; set; }


        public override string ToString()
        {
            return this.Nome.PrimeiroNome + " " + this.Nome.UltimoNome;
        }

        #region IEqualityComparer Members
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj == this)
                return true;

            if (!(obj is Usuario))
                return false;

            Usuario outro = (Usuario)obj;

            return Id.Equals(outro.Id);

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion #region IEqualityComparer Members


    }
}
