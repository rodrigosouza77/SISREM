using prmToolkit.NotificationPattern;
using SisRem.Domain.Entities.Base;
using SisRem.Domain.Enum;
using System;
using System.Collections.Generic;

namespace SisRem.Domain.Entities.Log
{
    public class LogAplicacao : EntityBase
    {
        public string ValorEvento { get; set; }
        public DateTime DtEvento { get; set; }
        public string DsEvento { get; set; }
        public int IDUsuario { get; set; }
        public virtual Usuario UsuarioEvento { get; set; }
        public EnumIdTabela IdTabela { get; set; }
        public IList<LogAplicacaoCampo> LogsCampos { get; set; }

        #region IEqualityComparer Members
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj == this)
                return true;

            if (!(obj is LogAplicacao))
                return false;

            LogAplicacao outro = (LogAplicacao)obj;

            return Id.Equals(outro.Id);

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion #region IEqualityComparer Members



    }
}
