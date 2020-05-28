using System.Data.Entity.ModelConfiguration;
using SisRem.Domain.Entities;

namespace SisRem.Infra.Persistence.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {


            this.ToTable("Usuario");
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome.PrimeiroNome)
                .HasMaxLength(60);

            this.Property(t => t.Nome.UltimoNome)
                .HasMaxLength(60);

            this.Property(t => t.Email.Endereco)
                .HasMaxLength(200);

            this.Property(t => t.Senha)
                .HasMaxLength(100);

            this.Property(t => t.Status);

            this.Property(t => t.Id).HasColumnName("IDUsuario");
            this.Property(t => t.Nome.PrimeiroNome).HasColumnName("PrimeiroNome");
            this.Property(t => t.Nome.UltimoNome).HasColumnName("UltimoNome");
            this.Property(t => t.Email.Endereco).HasColumnName("Email");
            this.Property(t => t.Senha).HasColumnName("Senha");
            this.Property(t => t.Status).HasColumnName("Status");



        }
    }
}
