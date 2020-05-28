using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SisRem.Domain.Entities;
using SisRem.Infra.Persistence.Map;
using SisRem.Domain.Entities.Log;

namespace SisRem.Infra.Persistence
{
    public class SisRemContext : DbContext
    {
        public SisRemContext() : base("SisRem")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Usuario> Usuarios { get; set; }
        public IDbSet<LogAplicacao> LogsAplicacao { get; set; }
        public IDbSet<LogAplicacaoCampo> LogsCampos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Seta o Schema default
            //modelBuilder.HasDefaultSchema("Apoio");

            //Remove a pluralização dos nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Remove exclusão em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Setar para usar varchar ou invés de nvarchar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Caso eu esqueça de informar o tamanho do campo ele irá colocar varchar de 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //Mapeia as entidades
            //modelBuilder.Configurations.Add(new MapUsuario());
            //modelBuilder.Configurations.Add(new MapLogAplicacao());

            #region Adiciona entidades mapeadas - Automaticamente via Assembly
            modelBuilder.Configurations.AddFromAssembly(typeof(SisRemContext).Assembly);
            #endregion

            #region Adiciona entidades mapeadas - Automaticamente via NameSpace
            //Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => type.Namespace == "AlertaBrasil.Domain.Entities.DomainViagem")
            //    .ToList()
            //    .ForEach(type =>
            //    {
            //        dynamic instance = Activator.CreateInstance(type);
            //        modelBuilder.Configurations.Add(instance);
            //    });
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
