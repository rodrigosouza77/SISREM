using SisRem.Infra.Persistence;

namespace SisRem.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SisRemContext _context;

        public UnitOfWork(SisRemContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
