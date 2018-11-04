namespace OutdorAdvManage.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}