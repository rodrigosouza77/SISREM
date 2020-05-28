using SisRem.Domain.Entities.Log;
using SisRem.Domain.Interfaces.Repositories;
using SisRem.Infra.Persistence.Repositories.Base;

namespace SisRem.Infra.Persistence.Repositories
{
    public class LogAplicacaoRepository : RepositoryBase<LogAplicacao, int>, LogAplicacaoIRepository
    {
        protected readonly SisRemContext _context;

        public LogAplicacaoRepository(SisRemContext context) : base(context)
        {
            _context = context;
        }

    }
}
