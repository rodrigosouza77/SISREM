using SisRem.Domain.Entities.Log;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SisRem.Infra.Persistence.Map
{
    public class MapLogAplicacaoCampo : EntityTypeConfiguration<LogAplicacaoCampo>
    {
        public MapLogAplicacaoCampo()
        {
            ToTable("LogAplicacaoCampo");

            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("IDLogAplicacaoCampo");
            Property(c => c.Campo);
            Property(c => c.ValorAnterior);
            Property(c => c.ValorNovo);
            Property(c => c.Justificativa);
            Property(c => c.ValorNovo);

            HasRequired(p => p.LogAplicacao)
           .WithMany(b => b.LogsCampos)
           .HasForeignKey(p => p.IDLogAplicacao);

        }
    }

}
