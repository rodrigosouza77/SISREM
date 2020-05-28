using System.Data.Entity.ModelConfiguration;
using SisRem.Domain.Entities.Log;
using SisRem.Domain.Entities.Base;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisRem.Infra.Persistence.Map
{
    public class LogAplicacaoMap : EntityTypeConfiguration<LogAplicacao>
    {
        public LogAplicacaoMap()
        {
            ToTable("LogAplicacao");
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("IDLogAplicacao");
            Property(c => c.DtEvento);
            Property(c => c.DsEvento).HasMaxLength(200);
            Property(c => c.ValorEvento).HasMaxLength(200);
            Property(c => c.IdTabela).HasColumnName("IDTabela");

             HasRequired(p => p.UsuarioEvento)
            .WithMany(b => b.LogsAplicacao)
            .HasForeignKey(p => p.IDUsuario);

        }


    }
}
