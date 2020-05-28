using Microsoft.Practices.Unity;
using prmToolkit.NotificationPattern;
using System.Data.Entity;
using SisRem.Domain.Interfaces.Repositories;
using SisRem.Domain.Interfaces.Repositories.Base;
using SisRem.Domain.Interfaces.Services;
using SisRem.Domain.Services;
using SisRem.Infra.Persistence;
using SisRem.Infra.Persistence.Repositories;
using SisRem.Infra.Persistence.Repositories.Base;
using SisRem.Infra.Transactions;

namespace SisRem.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {

            container.RegisterType<DbContext, SisRemContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            //container.RegisterType(typeof(IServiceBase<,>), typeof(ServiceBase<,>));

            container.RegisterType<UsuarioIService, UsuarioService>(new HierarchicalLifetimeManager());
            container.RegisterType<LogAplicacaoIService, LogAplicacaoService>(new HierarchicalLifetimeManager());
            container.RegisterType<LogAplicacaoCampoIService, LogAplicacaoCampoService>(new HierarchicalLifetimeManager());

            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            container.RegisterType<UsuarioIRepository, UsuarioRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<LogAplicacaoIRepository, LogAplicacaoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<LogAplicacaoCampoIRepository, LogAplicacaoCampoRepository>(new HierarchicalLifetimeManager());



        }
    }
}
