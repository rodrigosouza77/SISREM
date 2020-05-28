
using SisRem.Domain.Entities.Log;
using SisRem.Domain.Interfaces.Repositories;
using SisRem.Infra.Persistence.Repositories.Base;

namespace SisRem.Infra.Persistence.Repositories
{
    public class LogAplicacaoCampoRepository : RepositoryBase<LogAplicacaoCampo, int>, LogAplicacaoCampoIRepository
    {

        protected readonly SisRemContext _context;

        public LogAplicacaoCampoRepository(SisRemContext context) : base(context)
        {
            _context = context;
        }


    }
}
