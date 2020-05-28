namespace SisRem.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
